using System.Linq;

namespace Read.Domain.Cars
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
                    c.CarType.Name.ToLower()
                    .Contains(name.ToLower())
                );
        }

        public IQueryable<Car> GetAll()
        {
            return this.carRepository.Get();
        }
    }
}
