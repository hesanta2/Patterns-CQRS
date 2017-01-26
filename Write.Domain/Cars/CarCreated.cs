using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Write.Domain.Events;

namespace Write.Domain.Cars
{
    public class CarCreated : DomainEvent
    {
        public Car Car { get; set; }

        public CarCreated(Car car)
        {
            this.Car = car;
        }
    }
}
