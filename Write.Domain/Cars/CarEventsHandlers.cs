using CQRS.Read.Infrastructure.Persistence.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS.Write.Domain.Events;

namespace CQRS.Write.Domain.Cars
{
    public class CarEventHandlers : IEventHandler<CarCreatedEvent>, IEventHandler<CarDeletedEvent>
    {
        private readonly ICarRepository carRepository;

        public CarEventHandlers(ICarRepository carRepository)
        {
            this.carRepository = carRepository;
        }

        public void Handle(CarCreatedEvent @event)
        {
            CQRS.Read.Infrastructure.Persistence.Cars.Car car = new CQRS.Read.Infrastructure.Persistence.Cars.Car
                            (
                                @event.Id,
                                (CQRS.Read.Infrastructure.Persistence.Cars.CarClass)@event.Class,
                                @event.Name,
                                @event.MaxSpeed,
                                @event.Doors
                            );
            this.carRepository.Insert(car);
        }

        public void Handle(CarDeletedEvent @event)
        {
            this.carRepository.Delete(@event.AggregateId);
        }

    }
}
