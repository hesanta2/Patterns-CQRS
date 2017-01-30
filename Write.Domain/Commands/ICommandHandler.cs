using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS.Write.Domain.Commands;

namespace Domain.Command
{
    public interface ICommandHandler<T> : ICommandHandler where T : ICommand
    {
        void Handle(T command);
    }

    public interface ICommandHandler { }
}
