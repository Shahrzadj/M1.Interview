using System.Collections.Generic;
using System.Threading.Tasks;
using Personnel.Entities.Personnel;

namespace Personnel.Data.Contracts
{
    public interface IPersonnelRepository : IRepository<Personnel.Entities.Personnel.PersonnelModel>
    {
       List<PersonnelModel> GetAll();
    }
}
