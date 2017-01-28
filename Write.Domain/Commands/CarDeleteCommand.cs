using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Write.Domain.Cars;
using Write.Domain.Commands;

namespace Write.Domain.Commands
{
    public class CarDeleteCommand : ICommand
    {
        public int Id { get; set; }
        public CarDeleteCommand(int id) { this.Id = id; }
    }
}
