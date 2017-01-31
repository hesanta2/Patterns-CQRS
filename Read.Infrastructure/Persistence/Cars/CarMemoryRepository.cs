using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CQRS.Read.Infrastructure.Persistence.Cars
{
    public class CarMemoryRepository : ICarRepository
    {
        private static List<Car> carMemoryList = new List<Car>();

        public void Insert(Car entity)
        {
            if (entity.Id == -1)
                entity = new Car(carMemoryList.Count + 1, entity.Class, entity.Name, entity.MaxSpeed, entity.Doors);

            carMemoryList.Add(entity);
        }

        public void Update(Car entity)
        {
            var repositoryItem = this.Find(entity.Id);

            repositoryItem.Class = entity.Class;
            repositoryItem.Name = entity.Name;
            repositoryItem.MaxSpeed = entity.MaxSpeed;
            repositoryItem.Doors = entity.Doors;
        }

        public void Delete(Car entity)
        {
            carMemoryList.Remove(entity);
        }

        public void Delete(object id)
        {
            carMemoryList.Remove(this.Find(id));
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
