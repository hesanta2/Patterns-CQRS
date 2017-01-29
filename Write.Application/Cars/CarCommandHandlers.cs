using System.Linq;
using Write.Domain.Cars;
using Write.Domain.Commands;
using System;
using Domain.Command;

namespace Write.Application.Cars
{
    public class CarCommandHandlers : ICommandHandler<CarCreateCommand>, ICommandHandler<CarDeleteCommand>, ICommandHandler
    {
        private readonly ICommandEventRepository eventRepository;
        private readonly Read.Infrastructure.Persistence.Cars.ICarRepository carRepository;

        public CarCommandHandlers(Read.Infrastructure.Persistence.Cars.ICarRepository carRepository, ICommandEventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
            this.carRepository = carRepository;
        }

        public void Handle(CarCreateCommand command)
        {
            Car item = new Car(this.carRepository.Get().Count() + 1, command.CarClass, command.Name, command.MaxSpeed, command.Doors);

            this.eventRepository.Save(item);
        }

        public void Handle(CarDeleteCommand command)
        {
            Car item = this.eventRepository.GetById<Car>(command.Id);
            item.Delete();
            this.eventRepository.Save(item);
        }
    }
}
