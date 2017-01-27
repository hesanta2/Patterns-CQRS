using Domain.CommandHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Write.Domain.Cars;
using Write.Domain.Commands;

namespace Write.Domain.Commands
{
    public class CarCommandHandlers : ICommandHandler<CarCreateCommand>, ICommandHandler<CarCreateCommand2>
    {
        private readonly ICommandEventRepository eventRepository;

        public CarCommandHandlers(ICommandEventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        public void Handle(object sender, CarCreateCommand command)
        {
            Car item = new Car(command.CarClass, command.Name, command.MaxSpeed, command.Doors);

            this.eventRepository.Save(item); 
        }

        public void Handle(object sender, CarCreateCommand2 command)
        {
        }
    }
}
