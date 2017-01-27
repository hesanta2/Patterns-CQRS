﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Write.Domain.Cars;

namespace Write.Domain.Events
{
    public class CarCreated : Event
    {
        public int Id { get; }
        public CarClass Class { get; }
        public string Name { get; }
        public int MaxSpeed { get; }
        public int Doors { get; }

        public CarCreated(int id, CarClass carClass, string name, int maxSpeed, int doors)
        {
            this.Id = id;
            this.Class = carClass;
            this.Name = name;
            this.MaxSpeed = maxSpeed;
            this.Doors = doors;
        }
    }
}