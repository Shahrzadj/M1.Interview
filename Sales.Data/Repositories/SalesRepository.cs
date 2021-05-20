using System;
using System.Collections.Generic;
using System.Text;
using Sales.Data.Contracts;

namespace Sales.Data.Repositories
{
    public class SalesRepository : Repository<Entities.Sales.Sales>, ISalesRepository
    {
        public SalesRepository(SalesDbContext dbContext) : base(dbContext)
        {
        }
    }
}
