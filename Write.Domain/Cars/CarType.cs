using System;

namespace CQRS.Write.Domain.Cars
{
    public struct CarType
    {
        public CarClass Class { get; private set; }
        public string Name { get; private set; }
        public int MaxSpeed { get; private set; }
        public int Doors { get; private set; }

        public CarType(CarClass carClass, String name, int maxSpeed, int doors)
        {
            this.Class = carClass;
            this.Name = name;
            this.MaxSpeed = maxSpeed;
            this.Doors = doors;
        }
    }
}