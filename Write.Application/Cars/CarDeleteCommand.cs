using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS.Write.Domain.Commands;

namespace CQRS.Write.Application.Cars
{
    public class CarDeleteCommand : ICommand
    {
        public int Id { get; set; }
        public CarDeleteCommand(int id) { this.Id = id; }
    }
}
