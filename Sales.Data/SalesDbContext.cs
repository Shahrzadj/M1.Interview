using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;

namespace Sales.Data
{
    public class SalesDbContext: DbContext
    {
        public SalesDbContext(DbContextOptions<SalesDbContext> options)
            :base(options) { }

        public DbSet<Entities.Sales.Sales> Sales { get; set; }
    }
}
