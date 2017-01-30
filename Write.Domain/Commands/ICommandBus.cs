using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS.Write.Domain.Events;

namespace CQRS.Write.Domain.Commands
{
    public interface ICommandBus : ICommandSender, IEventPublisher { }
}
