using System;
using System.Linq;
using Read.Application.Cars;
using Microsoft.Practices.Unity;
using Write.Domain.Commands;
using Write.Infrastructure.Commands;
using Write.Domain.Events;
using Read.Infrastructure.Persistence.Cars;

namespace ConsoleApplication
{
    class Program
    {
        private static ICommandBus commandBus;
        private static ICarRepository carRepository;
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
                IQueryable<Car> cars = carService.GetAll();
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
                                commandBus.Send(new CarCreateCommand((Write.Domain.Cars.CarClass)random.Next(2), readerLine, random.Next(150, 370), random.Next(0, 5)));
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
            carRepository = UnityConfigurator.UnityContainer.Resolve<ICarRepository>();
            carService = UnityConfigurator.UnityContainer.Resolve<ICarService>();
            ICommandEventRepository commandEventRepository = new MemoryCommandEventRepository(commandBus);

            CarCommandHandlers carCreateCommandHandlers = new CarCommandHandlers(carRepository, commandEventRepository);
            commandBus.RegisterCommandHandler<CarCreateCommand>(carCreateCommandHandlers.Handle);
            commandBus.RegisterCommandHandler<CarDeleteCommand>(carCreateCommandHandlers.Handle);

            CarEventHandlers carEventHandlers = new CarEventHandlers(carRepository);
            commandBus.RegisterEventHandler<CarCreatedEvent>(carEventHandlers.Handle);
            commandBus.RegisterEventHandler<CarDeletedEvent>(carEventHandlers.Handle);

            commandBus.Send(new CarCreateCommand(Write.Domain.Cars.CarClass.Sport | Write.Domain.Cars.CarClass.Competition, "Ferrari Formula One", 370, 0));
            commandBus.Send(new CarCreateCommand(Write.Domain.Cars.CarClass.Sport, "Audi R8", 335, 2));
            commandBus.Send(new CarCreateCommand(Write.Domain.Cars.CarClass.Normal | Write.Domain.Cars.CarClass.Sport, "Seat Leon FR", 260, 5));
            commandBus.Send(new CarCreateCommand(Write.Domain.Cars.CarClass.Normal, "Seat Leon", 220, 5));
        }
    }
}
