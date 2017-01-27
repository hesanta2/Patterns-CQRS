using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Write.Domain.Events
{
    public interface IEventHandler<T> : IEventHandler where T : Event
    {
        void Handle(T domainEvent);
    }

    public interface IEventHandler { }
}
