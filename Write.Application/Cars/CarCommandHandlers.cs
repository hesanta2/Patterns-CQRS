using System.Linq;
using CQRS.Write.Domain.Cars;
using CQRS.Write.Domain.Commands;
using System;
using Domain.Command;
using CQRS.Read.Infrastructure.Persistence;
using CQRS.Read.Application.Cars;

namespace CQRS.Write.Application.Cars
{
    public class CarCommandHandlers : ICommandHandler<CarCreateCommand>, ICommandHandler<CarDeleteCommand>, ICommandHandler
    {
        private readonly ICommandEventRepository eventRepository;
        private readonly ICarService carService;

        public CarCommandHandlers(ICarService carService, ICommandEventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
            this.carService = carService;
        }

        public void Handle(CarCreateCommand command)
        {
            Car item = new Car(this.carService.GetAll().Count() + 1, command.CarClass, command.Name, command.MaxSpeed, command.Doors);

            this.eventRepository.Save(item);
        }

        public void Handle(CarRenameCommand command)
        {
            Car item = this.eventRepository.GetByCommandId<Car>(command.Id);
            item.Rename(command.Name);
            this.eventRepository.Save(item);
        }

        public void Handle(CarDeleteCommand command)
        {
            Car item = this.eventRepository.GetByCommandId<Car>(command.Id);
            item.Delete();
            this.eventRepository.Save(item);
        }
    }
}
