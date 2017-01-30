using CQRS.Read.Infrastructure.Persistence.Cars;
using System.Linq;

namespace CQRS.Read.Application.Cars
{
    public interface ICarService : IApplicationService<Car>
    {
        IQueryable<Car> GetByName(string name);
        IQueryable<Car> GetAll();
    }
}
