using CQRS.Read.Infrastructure.Persistence.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS.Write.Domain.Events;
using CQRS.Read.Infrastructure.Persistence;

namespace CQRS.Write.Domain.Cars
{
    public class CarEventHandlers : IEventHandler<CarCreatedEvent>, IEventHandler<CarDeletedEvent>
    {
        private readonly IDataContext dataContext;

        public CarEventHandlers(IDataContext dataContext)
        {
            this.dataContext = dataContext;
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
            this.dataContext.Cars.Insert(car);
        }

        public void Handle(CarDeletedEvent @event)
        {
            this.dataContext.Cars.Delete(@event.AggregateId);
        }

    }
}
