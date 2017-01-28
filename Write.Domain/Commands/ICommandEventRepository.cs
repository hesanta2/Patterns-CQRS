using System;
using Write.Domain;
using Write.Domain.Events;

namespace Write.Domain.Commands
{
    public interface ICommandEventRepository
    {
        void Save(IAggregateRoot aggregate);
        T GetById<T>(object id) where T : IAggregateRoot;
    }
}