using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Write.Domain.Commands;
using Write.Domain.Messaging;

namespace Write.Infrastrucure.Messaging
{
    public class MemoryCommandBus : ICommandBus
    {
        public event EventHandler<ICommand> CommandSended;

        private List<ICommand> commands;

        public void Send<T>(T command) where T : ICommand
        {
            if (this.commands == null) this.commands = new List<ICommand>();

            this.commands.Add(command);

            if (CommandSended != null) CommandSended(this, command);
        }
    }
}
