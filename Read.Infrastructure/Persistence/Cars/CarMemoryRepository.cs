using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Read.Infrastructure.Persistence.Cars
{
    public class CarMemoryRepository : ICarRepository
    {
        [ThreadStatic]
        private static List<Car> carMemoryList = new List<Car>()
        {
            new Car(1, CarClass.Sport | CarClass.Competition, "Ferrari Formula One", 370, 0),
            new Car(2, CarClass.Sport, "Audi R8", 335, 2),
            new Car(4, CarClass.Normal | CarClass.Sport, "Seat Leon FR", 260, 5),
            new Car(3, CarClass.Normal, "Seat Leon", 220, 5)
        };

        public void Insert(Car entity)
        {
            if (entity.Id == -1)
                entity = new Car(carMemoryList.Count + 1, entity.Class, entity.Name, entity.MaxSpeed, entity.Doors);

            carMemoryList.Add(entity);
        }

        public void Delete(Car entity)
        {
            carMemoryList.Remove(entity);
        }

        public IQueryable<Car> Get(Expression<Func<Car, bool>> predicate = null)
        {
            return predicate != null ?
                    carMemoryList.AsQueryable().Where(predicate)
                    : carMemoryList.AsQueryable();
        }

        public Car Find(object id)
        {
            return carMemoryList.AsQueryable().FirstOrDefault(c => c.Id.Equals(id));
        }

    }
}
