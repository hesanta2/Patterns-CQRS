using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Write.Domain.Commands;

namespace Write.Domain.Commands
{
    public interface ICommandSender
    {
        void RegisterCommandHandler<T>(EventHandler<T> commandHandler) where T : ICommand;

        void Send<T>(T command) where T : ICommand;
    }
}
