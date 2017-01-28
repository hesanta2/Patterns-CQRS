using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Write.Domain.Cars;
using Write.Domain.Events;

namespace Write.Domain.Cars
{
    public class CarDeletedEvent : Event
    {
        public int AggregateId { get; }

        public CarDeletedEvent(int aggregateId) { this.AggregateId = aggregateId; }
    }
}
