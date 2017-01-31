using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS.Write.Domain.Events;

namespace CQRS.Write.Domain.Cars
{
    public class CarRenamedEvent : Event
    {
        public int AggregateId { get; }
        public string Name { get; }

        public CarRenamedEvent(int aggregateId, string name) : base()
        {
            this.AggregateId = aggregateId;
            this.Name = name;
        }
    }
}
