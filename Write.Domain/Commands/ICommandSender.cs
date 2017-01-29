﻿using Domain.Command;
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
        void RegisterCommandHandlers(ICommandHandler commandHandler);
        void Send<T>(T command) where T : ICommand;
    }
}
