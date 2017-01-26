using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Write.Domain.Cars;
using Write.Domain.Commands;

namespace Write.Domain.Cars
{
    public class CreateCarCommand : ICommand
    {
        public CarClass CarClass { get; set; }
        public string Name { get; set; }
        public int MaxVelocity { get; set; }
        public int Doors { get; set; }

        public CreateCarCommand(CarClass carClass, string name, int maxVelocity, int doors)
        {
            this.CarClass = carClass;
            this.Name = name;
            this.MaxVelocity = maxVelocity;
            this.Doors = doors;
        }
    }
}
