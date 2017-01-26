using System;
using Write.Domain.Events;

namespace Write.Domain.Cars
{
    public class Car : IAggregateRoot<int>
    {
        public int Id { get; protected set; }
        public CarType CarType { get; protected set; }

        public Car(int id, CarClass carClass, string name, int maxSpeed, int doors)
        {
            this.Id = id;
            this.CarType = new CarType(carClass, name, maxSpeed, doors);
        }
        public Car(CarClass carClass, string name, int maxSpeed, int doors)
        {
            this.Id = -1;
            this.CarType = new CarType(carClass, name, maxSpeed, doors);
        }

        public override string ToString()
        {
            return $"{this.CarType.Name}: [Class]{CarType.Class}, [MaxVelocity]{CarType.MaxSpeed}, [Doors]{CarType.Doors}";
        }

    }
}