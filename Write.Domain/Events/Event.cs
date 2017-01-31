using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Write.Domain.Events
{
    public abstract class Event : IEvent
    {
        public string Type { get { return this.GetType().Name; } }
        public int Version { get; set; }
    }
}
