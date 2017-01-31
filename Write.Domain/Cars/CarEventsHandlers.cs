using CQRS.Read.Infrastructure.Persistence.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS.Write.Domain.Events;
using CQRS.Read.Infrastructure.Persistence;
using CQRS.Read.Application.Cars;

namespace CQRS.Write.Domain.Cars
{
    public class CarEventHandlers : IEventHandler<CarCreatedEvent>, IEventHandler<CarDeletedEvent>
    {
        private readonly ICarService carService;

        public CarEventHandlers(ICarService carService)
        {
            this.carService = carService;
        }

        public void Handle(CarCreatedEvent @event)
        {
            CQRS.Read.Infrastructure.Persistence.Cars.Car car = new CQRS.Read.Infrastructure.Persistence.Cars.Car
                            (
                                @event.AggregateId,
                                (CQRS.Read.Infrastructure.Persistence.Cars.CarClass)@event.Class,
                                @event.Name,
                                @event.MaxSpeed,
                                @event.Doors
                            );
            this.carService.Insert(car);
        }

        public void Handle(CarRenamedEvent @event)
        {
            var item = this.carService.Find(@event.AggregateId);
            item.Name = @event.Name;
            this.carService.Update(item);
        }

        public void Handle(CarDeletedEvent @event)
        {
            this.carService.Delete(@event.AggregateId);
        }

    }
}
