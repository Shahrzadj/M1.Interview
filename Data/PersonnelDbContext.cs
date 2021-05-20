using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Personnel.Entities.Personnel;

namespace Data
{
    public class PersonnelDbContext: DbContext
    {
        public PersonnelDbContext(DbContextOptions<PersonnelDbContext> options)
            :base(options) { }

        public DbSet<PersonnelModel> Personnel { get; set; }
    }
}
