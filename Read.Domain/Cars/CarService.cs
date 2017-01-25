using Read.Infrasctructure.Persistence.Cars;
using System.Linq;

namespace Read.Application.Cars
{
    public class CarService : ICarService
    {
        private readonly ICarRepository carRepository;

        public CarService(ICarRepository carRepository)
        {
            this.carRepository = carRepository;
        }

        public IQueryable<Car> GetByName(string name)
        {
            return this.carRepository.Get
                (
                    c =>
                    c.Name.ToLower()
                    .Contains(name.ToLower())
                );
        }

        public IQueryable<Car> GetAll()
        {
            return this.carRepository.Get();
        }
    }
}
