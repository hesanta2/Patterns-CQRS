using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace CQRS.Read.Infrastructure.Persistence.Cars
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
        public int Id { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public CarClass Class { get; set; }
        public string Name { get; set; }
        public int MaxSpeed { get; set; }
        public int Doors { get; set; }

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