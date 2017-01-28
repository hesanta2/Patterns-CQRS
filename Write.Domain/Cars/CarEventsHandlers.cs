using Read.Infrastructure.Persistence.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Write.Domain.Events;

namespace Write.Domain.Cars
{
    public class CarEventHandlers : IEventHandler<CarCreatedEvent>
    {
        private readonly ICarRepository carRepository;

        public CarEventHandlers(ICarRepository carRepository)
        {
            this.carRepository = carRepository;
        }

        public void Handle(object sender, CarCreatedEvent @event)
        {
            Read.Infrastructure.Persistence.Cars.Car car = new Read.Infrastructure.Persistence.Cars.Car
                            (
                                @event.Id,
                                (Read.Infrastructure.Persistence.Cars.CarClass)@event.Class,
                                @event.Name,
                                @event.MaxSpeed,
                                @event.Doors
                            );
            this.carRepository.Insert(car);
        }

        public void Handle(object sender, CarDeletedEvent @event)
        {
            this.carRepository.Delete(@event.AggregateId);
        }

    }
}
