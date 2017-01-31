using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS.Write.Domain.Events;

namespace CQRS.Write.Domain.Test.ForTesting
{
    public class TestAgrregateRootCreateEvent : Event
    {
        public int Id { get; }

        public TestAgrregateRootCreateEvent(int id)
        {
            this.Id = id;
        }
    }
}
