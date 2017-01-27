using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Write.Domain.Commands;
using Write.Domain.Events;

namespace Write.Infrastrucure.Commands
{
    public class MemoryCommandBus : ICommandBus
    {
        private event EventHandler<ICommand> registerCommandHandlers;
        private event EventHandler<IEvent> registerEventHandlers;

        public void RegisterCommandHandler<T>(EventHandler<T> commandHandler) where T : ICommand
        {
            registerCommandHandlers += (s, e) =>
            {
                if (!e.GetType().Equals(typeof(T))) return;

                commandHandler(s, (T)e);
            };
        }

        public void Send<T>(T command) where T : ICommand
        {
            if (this.registerCommandHandlers != null)
            {
                this.registerCommandHandlers(this, command);
            }
            else
                throw new InvalidOperationException("No command 'Handler' registered");
        }

        public void RegisterEventHandler<T>(EventHandler<T> eventHandler) where T : IEvent
        {
            registerEventHandlers += (s, e) =>
            {
                if (!e.GetType().Equals(typeof(T))) return;

                eventHandler(s, (T)e);
            };
        }

        public void Publish<T>(T @event) where T : IEvent
        {
            if (this.registerEventHandlers != null)
            {
                this.registerEventHandlers(this, @event);
            }
            else
                throw new InvalidOperationException("No event 'Handler' registered");
        }
    }
}
