using Domain.CommandHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Write.Domain.Cars;

namespace Write.Domain.Commands
{
    public class CarCommandHandlers : ICommandHandler<CarCreateCommand>, ICommandHandler<CarCreateCommand2>
    {
        public void Handle(object sender, CarCreateCommand command)
        {
        }

        public void Handle(object sender, CarCreateCommand2 command)
        {
        }
    }
}
