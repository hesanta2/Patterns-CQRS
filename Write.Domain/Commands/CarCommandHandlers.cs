using Domain.CommandHandlers;
using Write.Domain.Cars;
using System.Linq;

namespace Write.Domain.Commands
{
    public class CarCommandHandlers : ICommandHandler<CarCreateCommand>
    {
        private readonly ICommandEventRepository eventRepository;
        private readonly Read.Infrastructure.Persistence.Cars.ICarRepository carRepository;

        public CarCommandHandlers(Read.Infrastructure.Persistence.Cars.ICarRepository carRepository, ICommandEventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
            this.carRepository = carRepository;
        }

        public void Handle(object sender, CarCreateCommand command)
        {
            Car item = new Car(this.carRepository.Get().Count() + 1, command.CarClass, command.Name, command.MaxSpeed, command.Doors);

            this.eventRepository.Save(item);
        }

        public void Handle(object sender, CarDeleteCommand command)
        {
            Car item = this.eventRepository.GetById<Car>(command.Id);
            item.Delete();
            this.eventRepository.Save(item);
        }

    }
}
