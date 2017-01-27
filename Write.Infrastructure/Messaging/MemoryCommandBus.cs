using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Write.Domain.Commands;
using Write.Domain.Events;

namespace Write.Infrastrucure.Messaging
{
    public class MemoryCommandBus : ICommandBus
    {
        private event EventHandler<ICommand> registerHandlers;

        public void Send<T>(T command) where T : ICommand
        {
            if (this.registerHandlers != null)
            {
                this.registerHandlers(this, command);
            }
            else
                throw new InvalidOperationException("No command 'Handler' registered");
        }

        public void Publish<T>(T @event) where T : Event
        {
            throw new NotImplementedException();
        }

        public void RegisterHandler<T>(EventHandler<T> commandHandler) where T : ICommand
        {
            registerHandlers += (s, e) =>
            {
                if (!e.GetType().Equals(typeof(T))) return;

                commandHandler(s, (T)e);
            };
        }

    }
}
