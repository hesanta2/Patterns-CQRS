using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS.Write.Domain.Events;

namespace CQRS.Write.Domain.Cars
{
    public class CarCreatedEvent : Event
    {
        public CarClass Class { get; }
        public string Name { get; }
        public int MaxSpeed { get; }
        public int Doors { get; }

        public CarCreatedEvent(int aggregateId, CarClass carClass, string name, int maxSpeed, int doors) : base()
        {
            this.AggregateId = aggregateId;
            this.Class = carClass;
            this.Name = name;
            this.MaxSpeed = maxSpeed;
            this.Doors = doors;
        }
    }
}
