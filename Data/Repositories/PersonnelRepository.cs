using Data;
using Personnel.Data.Contracts;

namespace Personnel.Data.Repositories
{
    public class PersonnelRepository: Repository<Personnel.Entities.Personnel.PersonnelModel>, IPersonnelRepository
    {
        public PersonnelRepository(PersonnelDbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
