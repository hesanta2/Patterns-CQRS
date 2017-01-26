using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Write.Infrastructure.Commands;

namespace Write.Infrastructure.Messaging
{
    public interface ICommandBus
    {
        void Send<T>(T command) where T : ICommand;
    }
}
