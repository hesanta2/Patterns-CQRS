using System;

namespace Read.Infrasctructure.Persistence.Cars
{
    [Flags]
    public enum CarClass
    {
        Normal,
        Sport,
        Competition
    }

    public class Car
    {
        public int Id { get; protected set; }
        public CarClass Class { get; private set; }
        public string Name { get; private set; }
        public int MaxSpeed { get; private set; }
        public int Doors { get; private set; }

        public Car(int id, CarClass carClass, string name, int maxSpeed, int doors)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("name");

            this.Id = id;
            this.Class = carClass;
            this.Name = name;
            this.MaxSpeed = maxSpeed;
            this.Doors = doors;
        }
        public Car(CarClass carClass, string name, int maxSpeed, int doors)
        {
            this.Id = -1;
            this.Class = carClass;
            this.Name = name;
            this.MaxSpeed = maxSpeed;
            this.Doors = doors;
        }

        public override string ToString()
        {
            return $"{this.Name}: [Class]{this.Class}, [MaxVelocity]{this.MaxSpeed}, [Doors]{this.Doors}";
        }

    }
}