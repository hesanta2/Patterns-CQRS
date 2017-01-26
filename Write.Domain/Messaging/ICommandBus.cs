using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Write.Domain.Commands;

namespace Write.Domain.Messaging
{
    public interface ICommandBus
    {
        event EventHandler<ICommand> CommandSended;
        void Send<T>(T command) where T : ICommand;
    }
}
