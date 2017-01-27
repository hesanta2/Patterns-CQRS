using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Write.Domain.Events;

namespace Write.Domain
{
    public class AggregateRoot<T> : IAggregateRoot<T>
    {
        private List<IEvent> eventChanges = new List<IEvent>();

        public T Id { get; protected set; }
        public int Version { get; }

        public object GetId() { return Id; }

        public IEnumerable<IEvent> GetUncommittedChanges()
        {
            return this.eventChanges;
        }

        public void LoadFromHistory(IEnumerable<IEvent> history)
        {
            foreach (var @event in history)
                this.ApplyChange(@event);
        }

        public void MarkChangesAsCommitted()
        {
            this.eventChanges.Clear();
        }

        public void ApplyChange(IEvent @event, bool isNew = true)
        {
            var method = this.GetType().GetMethod("Apply", BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { @event.GetType() }, null);
            if (method == null)
                throw new InvalidOperationException($"Can't apply changes for '{@event}' event. Missing Aggregate.Apply({@event}) method?");

            method.Invoke(this, new object[] { @event });

            if (isNew) this.eventChanges.Add(@event);
        }
    }
}
