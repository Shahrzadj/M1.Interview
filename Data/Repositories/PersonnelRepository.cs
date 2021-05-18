using System;
using System.Collections.Generic;
using System.Text;
using Data.Contracts;
using Entities.Personnel;


namespace Data.Repositories
{
    public class PersonnelRepository: Repository<Personnel>, IPersonnelRepository
    {
        public PersonnelRepository(PersonnelDbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
