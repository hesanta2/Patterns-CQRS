using CQRS.Read.Infrastructure.Persistence.Cars;

namespace CQRS.Read.Infrastructure.Persistence
{
    public interface IDataContext
    {
        ICarRepository Cars { get; set; }

    }
}