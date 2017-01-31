using CQRS.Read.Infrastructure.Persistence.Cars;
using System.Linq;
using System;

namespace CQRS.Read.Application.Cars
{
    public class CarService : ICarService
    {
        private readonly ICarRepository carRepository;

        public CarService(ICarRepository carRepository)
        {
            this.carRepository = carRepository;
        }

        public Car Find(int id)
        {
            return this.carRepository.Find(id);
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

        public void Update(Car item)
        {
            this.carRepository.Update(item);
        }

        public void Insert(Car car)
        {
            this.carRepository.Insert(car);
        }

        public void Delete(int id)
        {
            this.carRepository.Delete(id);
        }

    }
}
