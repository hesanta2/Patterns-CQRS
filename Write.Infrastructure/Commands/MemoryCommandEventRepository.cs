using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Write.Domain;
using Write.Domain.Commands;
using Write.Domain.Events;

namespace Write.Infrastructure.Commands
{
    public class MemoryCommandEventRepository : ICommandEventRepository
    {
        private IEventPublisher eventPublisher;
        private Dictionary<object, List<IEvent>> aggregateEventsDictonary = new Dictionary<object, List<IEvent>>();


        public MemoryCommandEventRepository(IEventPublisher eventPublisher)
        {
            this.eventPublisher = eventPublisher;
        }

        public void Save(IAggregateRoot aggregate)
        {
            List<IEvent> aggregateEvents;

            if (!aggregateEventsDictonary.TryGetValue(aggregate.GetId(), out aggregateEvents))
            {
                aggregateEvents = new List<IEvent>();
                aggregateEventsDictonary.Add(aggregate.GetId(), aggregateEvents);
            }

            //TODO: check whether latest event version matches current aggregate version

            foreach (var @event in aggregate.GetUncommittedChanges())
            {
                aggregateEvents.Add(@event);

                this.eventPublisher.Publish(@event);
            }

            aggregate.MarkChangesAsCommitted();
        }

        public T GetById<T>(object id) where T : IAggregateRoot
        {
            T aggregate = (T)Activator.CreateInstance(typeof(T)); ;

            List<IEvent> aggregateEvents;
            if (aggregateEventsDictonary.TryGetValue(id, out aggregateEvents))
            {
                aggregate.LoadsFromHistory(aggregateEvents);
                return aggregate;
            }

            return default(T);
        }


    }
}
