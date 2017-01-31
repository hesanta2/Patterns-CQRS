using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Write.Domain.Events
{
    public interface IEvent
    {
        string Type { get; }
        int Version { get; set; }
    }
}
