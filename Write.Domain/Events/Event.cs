using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Write.Domain.Events
{
    public abstract class Event : IEvent
    {
        public int Version { get; set; }
    }
}
