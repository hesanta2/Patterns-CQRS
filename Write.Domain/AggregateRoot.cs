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

        public void LoadsFromHistory(IEnumerable<IEvent> history)
        {
            foreach (var @event in history)
                this.ApplyChange(@event, false);
        }

        public void MarkChangesAsCommitted()
        {
            this.eventChanges.Clear();
        }

        public void ApplyChange(IEvent @event, bool isNew = true)
        {
            var method = this.GetType().GetMethod("Apply", BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { @event.GetType() }, null);
            if (method != null)
                method.Invoke(this, new object[] { @event });

            if (isNew) this.eventChanges.Add(@event);
        }
    }
}
