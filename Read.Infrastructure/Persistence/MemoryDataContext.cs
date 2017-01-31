using CQRS.Read.Infrastructure.Persistence.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CQRS.Read.Infrastructure.Persistence
{
    public class MemoryDataContext : IDataContext
    {
        public ICarRepository Cars { get; set; }

        public MemoryDataContext(ICarRepository carsRepository)
        {
            this.Cars = carsRepository;
        }
    }
}
