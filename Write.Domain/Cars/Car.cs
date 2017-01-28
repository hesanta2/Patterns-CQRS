using System;
using Write.Domain.Events;

namespace Write.Domain.Cars
{
    public class Car : AggregateRoot<int>
    {
        public CarType CarType { get; protected set; }

        public Car() { }
        public Car(int id, CarClass carClass, string name, int maxSpeed, int doors)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("name");

            this.ApplyChange(new CarCreatedEvent(id, carClass, name, maxSpeed, doors));
        }
        public Car(CarClass carClass, string name, int maxSpeed, int doors)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("name");

            this.ApplyChange(new CarCreatedEvent(0, carClass, name, maxSpeed, doors));
        }

        private void Apply(CarCreatedEvent @event)
        {
            this.Id = @event.Id;
            this.CarType = new CarType(@event.Class, @event.Name, @event.MaxSpeed, @event.Doors);
        }

        public void Delete()
        {
            this.ApplyChange(new CarDeletedEvent(this.Id));
        }

        public override string ToString()
        {
            return $"{this.CarType.Name}: [Class]{CarType.Class}, [MaxVelocity]{CarType.MaxSpeed}, [Doors]{CarType.Doors}";
        }

    }
}