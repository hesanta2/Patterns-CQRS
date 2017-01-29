using Domain.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Write.Domain.Cars;
using Write.Domain.Commands;

namespace Write.Application.Cars
{
    public class CarCreateCommand : ICommand
    {
        public CarClass CarClass { get; set; }
        public string Name { get; set; }
        public int MaxSpeed { get; set; }
        public int Doors { get; set; }

        public CarCreateCommand(CarClass carClass, string name, int maxVelocity, int doors)
        {
            this.CarClass = carClass;
            this.Name = name;
            this.MaxSpeed = maxVelocity;
            this.Doors = doors;
        }
    }
}
