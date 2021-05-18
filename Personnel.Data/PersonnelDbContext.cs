using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Personnel.Data
{
    public class PersonnelDbContext: DbContext
    {
        public PersonnelDbContext(DbContextOptions<PersonnelDbContext> options)
            :base(options) { }

        public DbSet<Entities.Personnel> Personnels { get; set; }
    }
}
