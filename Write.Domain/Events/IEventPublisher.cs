using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Write.Domain.Commands;

namespace Write.Domain.Events
{
    public interface IEventPublisher
    {
        void RegisterEventHandler<T>(EventHandler<T> eventHandler) where T : IEvent;
        void Publish<T>(T @event) where T : IEvent;
    }
}
