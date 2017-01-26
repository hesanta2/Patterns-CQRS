using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Write.Domain.Events
{
    public interface IDomainHandler<T> where T : DomainEvent
    {
        void Handle(T domainEvent);
    }

    public interface IDomainHandler { }
}
