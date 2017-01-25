using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Read.Infrasctructure.Persistence.Cars
{
    public class CarMemoryRepository : ICarRepository
    {
        private List<Car> carMemoryList = new List<Car>()
        {
            new Car(1, CarClass.Sport | CarClass.Competition, "Ferrari Formula One", 370, 0),
            new Car(2, CarClass.Sport, "Audi R8", 335, 2),
            new Car(4, CarClass.Normal | CarClass.Sport, "Seat Leon FR", 260, 5),
            new Car(3, CarClass.Normal, "Seat Leon", 220, 5)
        };

        public void Insert(Car entity)
        {
            this.carMemoryList.Add(entity);
        }

        public void Delete(Car entity)
        {
            this.carMemoryList.Remove(entity);
        }

        public IQueryable<Car> Get(Expression<Func<Car, bool>> predicate = null)
        {
            return predicate != null ?
                    this.carMemoryList.AsQueryable().Where(predicate)
                    : this.carMemoryList.AsQueryable();
        }

        public Car Find(object id)
        {
            return this.carMemoryList.AsQueryable().FirstOrDefault(c => c.Id.Equals(id));
        }

    }
}
