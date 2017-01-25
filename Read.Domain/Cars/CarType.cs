using System;

namespace Read.Domain.Cars
{
    public struct CarType
    {
        public CarClass Class { get; private set; }
        public string Name { get; private set; }
        public int MaxSpeed { get; private set; }
        public int Doors { get; private set; }

        public CarType(CarClass carClass, String name, int maxSpeed, int doors)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("name");

            this.Class = carClass;
            this.Name = name;
            this.MaxSpeed = maxSpeed;
            this.Doors = doors;
        }
    }
}