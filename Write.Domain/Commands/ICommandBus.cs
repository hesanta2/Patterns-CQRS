using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Write.Domain.Events;

namespace Write.Domain.Commands
{
    public interface ICommandBus : ICommandSender, IEventPublisher { }
}
