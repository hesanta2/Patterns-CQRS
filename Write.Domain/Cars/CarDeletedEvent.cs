using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS.Write.Domain.Cars;
using CQRS.Write.Domain.Events;

namespace CQRS.Write.Domain.Cars
{
    public class CarDeletedEvent : Event
    {
        public int AggregateId { get; }

        public CarDeletedEvent(int aggregateId) { this.AggregateId = aggregateId; }
    }
}
