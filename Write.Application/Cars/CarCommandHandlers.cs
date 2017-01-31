using System.Linq;
using CQRS.Write.Domain.Cars;
using CQRS.Write.Domain.Commands;
using System;
using Domain.Command;
using CQRS.Read.Infrastructure.Persistence;

namespace CQRS.Write.Application.Cars
{
    public class CarCommandHandlers : ICommandHandler<CarCreateCommand>, ICommandHandler<CarDeleteCommand>, ICommandHandler
    {
        private readonly ICommandEventRepository eventRepository;
        private readonly IDataContext dataContext;

        public CarCommandHandlers(IDataContext dataContext, ICommandEventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
            this.dataContext = dataContext;
        }

        public void Handle(CarCreateCommand command)
        {
            Car item = new Car(this.dataContext.Cars.Get().Count() + 1, command.CarClass, command.Name, command.MaxSpeed, command.Doors);

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
