using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Write.Domain.Commands;

namespace Domain.CommandHandlers
{
    public interface ICommandHandler<T> where T : ICommand
    {
        void Handle(object sender, T command);
    }
}
