using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Write.Domain.Commands;

namespace Write.Domain.Cars
{
    public class CarDeleteCommand : ICommand
    {
        public int Id { get; set; }
        public CarDeleteCommand(int id) { this.Id = id; }
    }
}
