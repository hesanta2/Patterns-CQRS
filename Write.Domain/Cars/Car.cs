using System;
using CQRS.Write.Domain.Events;

namespace CQRS.Write.Domain.Cars
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

        #region Rename
        public void Rename(string name)
        {
            this.ApplyChange(new CarRenamedEvent(this.Id, name));
        }
        private void Apply(CarRenamedEvent @event)
        {
            this.Id = @event.AggregateId;
            this.CarType = new CarType(this.CarType.Class, @event.Name, this.CarType.MaxSpeed, this.CarType.Doors);
        }
        #endregion

        #region Delete
        public void Delete()
        {
            this.ApplyChange(new CarDeletedEvent(this.Id));
        }
        private void Apply(CarCreatedEvent @event)
        {
            this.Id = @event.AggregateId;
            this.CarType = new CarType(@event.Class, @event.Name, @event.MaxSpeed, @event.Doors);
        }
        #endregion


        public override string ToString()
        {
            return $"{this.CarType.Name}: [Class]{CarType.Class}, [MaxVelocity]{CarType.MaxSpeed}, [Doors]{CarType.Doors}";
        }

    }
}