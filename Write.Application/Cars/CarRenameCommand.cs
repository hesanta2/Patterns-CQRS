using Domain.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS.Write.Domain.Cars;
using CQRS.Write.Domain.Commands;

namespace CQRS.Write.Application.Cars
{
    public class CarRenameCommand : Command
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CarRenameCommand(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
