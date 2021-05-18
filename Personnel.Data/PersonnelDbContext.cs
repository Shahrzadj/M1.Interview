using System;
using System.Collections.Generic;
using System.Text;
using Entities.Personnel;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class PersonnelDbContext: DbContext
    {
        public PersonnelDbContext(DbContextOptions<PersonnelDbContext> options)
            :base(options) { }

        public DbSet<Personnel> Personnels { get; set; }
    }
}
