using System;
using Write.Application;
using Write.Application.Events;

namespace Write.Application.Commands
{
    public interface ICommandEventRepository
    {
        void Save(IAggregateRoot aggregate);
        T GetById<T>(object id) where T : IAggregateRoot;
    }
}