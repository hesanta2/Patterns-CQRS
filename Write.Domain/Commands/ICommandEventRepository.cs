using System;
using CQRS.Write.Domain;
using CQRS.Write.Domain.Events;
using System.Collections.Generic;

namespace CQRS.Write.Domain.Commands
{
    public interface ICommandEventRepository
    {
        void Save(IAggregateRoot aggregate);
        T GetByCommandId<T>(object id) where T : IAggregateRoot;
        IEnumerable<IEvent> GetEvents(object id);
    }
}