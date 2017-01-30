using Microsoft.Practices.Unity;
using CQRS.Read.Application.Cars;
using System;
using System.Linq;
using CQRS.Write.Application.Cars;
using CQRS.Write.Domain.Cars;
using CQRS.Write.Domain.Commands;

namespace ConsoleApplication
{
    class Program
    {
        private static ICommandBus commandBus;
        private static ICarService carService;

        static void Main(string[] args)
        {
            InitApplication();

            Random random = new Random((int)DateTime.Now.Ticks);

            ConsoleKey consoleKey = ConsoleKey.A;
            while (consoleKey != ConsoleKey.Escape)
            {
                System.Console.Write(@"
- Car Searcher -
    1. Search
    2. Add (random)
    3. Remove
    Esc to exit

  Write number option: ");
                consoleKey = System.Console.ReadKey().Key;
                System.Console.Clear();
                string readerLine = null;
                IQueryable<CQRS.Read.Infrastructure.Persistence.Cars.Car> cars = carService.GetAll();
                while (true)
                {

                    System.Console.WriteLine();
                    foreach (var car in cars)
                        System.Console.WriteLine($"Car ({car.Id}): {car}");
                    System.Console.WriteLine();

                    switch (consoleKey)
                    {
                        case ConsoleKey.D1:
                            System.Console.Write("\nWrite the car name to find ('exit' to leave): ");
                            readerLine = System.Console.ReadLine();
                            cars = carService.GetByName(readerLine);
                            break;
                        case ConsoleKey.D2:
                            System.Console.Write("\nWrite the car name to create random one ('exit' to leave): ");
                            readerLine = System.Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(readerLine)
                                && readerLine.ToLower() != "exit")
                                commandBus.Send(new CarCreateCommand((CarClass)random.Next(2), readerLine, random.Next(150, 370), random.Next(0, 5)));
                            cars = carService.GetAll();
                            break;
                        case ConsoleKey.D3:
                            System.Console.Write("\nWrite the car Id to remove ('exit' to leave): ");
                            readerLine = System.Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(readerLine)) break;

                            int readerLineID;
                            int.TryParse(readerLine, out readerLineID);
                            try { commandBus.Send(new CarDeleteCommand(readerLineID)); }
                            catch { }
                            cars = carService.GetAll();
                            break;
                    }

                    if (readerLine == null
                        || readerLine.ToLower() == "exit")
                        break;
                }

                System.Console.Clear();

            }
        }

        private static void InitApplication()
        {
            commandBus = UnityConfigurator.UnityContainer.Resolve<ICommandBus>();
            CQRS.Read.Infrastructure.Persistence.Cars.ICarRepository carRepository = UnityConfigurator.UnityContainer.Resolve<CQRS.Read.Infrastructure.Persistence.Cars.ICarRepository>();
            carService = UnityConfigurator.UnityContainer.Resolve<ICarService>();
            ICommandEventRepository commandEventRepository = UnityConfigurator.UnityContainer.Resolve<ICommandEventRepository>();

            commandBus.RegisterCommandHandlers(new CarCommandHandlers(carRepository, commandEventRepository));
            commandBus.RegisterEventHandlers(new CarEventHandlers(carRepository));

            commandBus.Send(new CarCreateCommand(CarClass.Sport | CarClass.Competition, "Ferrari Formula One", 370, 0));
            commandBus.Send(new CarCreateCommand(CarClass.Sport, "Audi R8", 335, 2));
            commandBus.Send(new CarCreateCommand(CarClass.Normal | CarClass.Sport, "Seat Leon FR", 260, 5));
            commandBus.Send(new CarCreateCommand(CarClass.Normal, "Seat Leon", 220, 5));
        }
    }
}
