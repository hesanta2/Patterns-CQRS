using CQRS.Read.Infrastructure.Persistence.Cars;
using System.Linq;

namespace CQRS.Read.Application.Cars
{
    public interface ICarService : IApplicationService<Car>
    {
        Car Find(int id);
        IQueryable<Car> GetByName(string name);
        IQueryable<Car> GetAll();
        void Insert(Car car);
        void Update(Car item);
        void Delete(int id);
    }
}
