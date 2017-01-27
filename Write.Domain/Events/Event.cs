using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Write.Domain.Events
{
    public abstract class Event
    {
        public DateTime Created { get; private set; }

        public Event()
        {
            this.Created = DateTime.Now;
        }
    }
}
