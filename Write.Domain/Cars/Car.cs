using System;
using Write.Domain.Events;

namespace Write.Domain.Cars
{
    public class Car : AggregateRoot<int>
    {
        public CarType CarType { get; protected set; }

        public Car(int id, CarClass carClass, string name, int maxSpeed, int doors)
        {
            this.ApplyChange(new CarCreated(id, carClass, name, maxSpeed, doors));
        }
        public Car(CarClass carClass, string name, int maxSpeed, int doors)
        {
            this.ApplyChange(new CarCreated(0, carClass, name, maxSpeed, doors));
        }

        private void Apply(CarCreated @event)
        {
            this.Id = @event.Id;
            this.CarType = new CarType(@event.Class, @event.Name, @event.MaxSpeed, @event.Doors);
        }

        public override string ToString()
        {
            return $"{this.CarType.Name}: [Class]{CarType.Class}, [MaxVelocity]{CarType.MaxSpeed}, [Doors]{CarType.Doors}";
        }

    }
}