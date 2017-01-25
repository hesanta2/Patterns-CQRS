using Read.Infrasctructure.Persistence.Cars;
using System.Linq;

namespace Read.Application.Cars
{
    public interface ICarService : IApplicationService<Car>
    {
        IQueryable<Car> GetByName(string name);
        IQueryable<Car> GetAll();
    }
}
