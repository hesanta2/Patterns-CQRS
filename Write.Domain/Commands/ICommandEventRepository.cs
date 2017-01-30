using System;
using CQRS.Write.Domain;
using CQRS.Write.Domain.Events;

namespace CQRS.Write.Domain.Commands
{
    public interface ICommandEventRepository
    {
        void Save(IAggregateRoot aggregate);
        T GetById<T>(object id) where T : IAggregateRoot;
    }
}