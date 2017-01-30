using System.Collections.Generic;
using CQRS.Write.Domain.Events;

namespace CQRS.Write.Domain
{
    public interface IAggregateRoot<T> : IAggregateRoot
    {
        T Id { get; }
    }
    public interface IAggregateRoot
    {
        object GetId();
        int Version { get; }


        IEnumerable<IEvent> GetUncommittedChanges();

        void MarkChangesAsCommitted();

        void LoadsFromHistory(IEnumerable<IEvent> history);

        void ApplyChange(IEvent @event, bool isNew = true);
    }

}
