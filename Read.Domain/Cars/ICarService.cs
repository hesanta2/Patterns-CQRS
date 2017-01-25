using System.Linq;

namespace Read.Domain.Cars
{
    public interface ICarService : IDomainService<Car>
    {
        IQueryable<Car> GetByName(string name);
        IQueryable<Car> GetAll();
    }
}
