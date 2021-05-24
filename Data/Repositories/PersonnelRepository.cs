using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Personnel.Data.Contracts;
using Personnel.Entities.Personnel;

namespace Personnel.Data.Repositories
{
    public class PersonnelRepository: Repository<Personnel.Entities.Personnel.PersonnelModel>, IPersonnelRepository
    {
        public PersonnelRepository(PersonnelDbContext dbContext) 
            : base(dbContext)
        {
        }
        public async Task<List<PersonnelModel>> GetAllPersonnel()
        {
            return DbContext.Personnel.ToList();
        }
    }
}
