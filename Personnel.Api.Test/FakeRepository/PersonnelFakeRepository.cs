using Personnel.Entities.Personnel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Personnel.Data.Contracts;

namespace Personnel.Api.Test.FakeRepository
{
    public class PersonnelFakeRepository:IPersonnelRepository
    {
        private readonly List<PersonnelModel> _personnelList;

        public PersonnelFakeRepository()
        {
            _personnelList=new List<PersonnelModel>()
            {
                new PersonnelModel(){Id = 1,Name = "Shahrzad",Age = 28,Phone = "00989191677925"},
                new PersonnelModel() {Id = 2,Name = "sara",Age = 29,Phone = "00989124576377"}
            };
        }

        public DbSet<PersonnelModel> Entities => throw new NotImplementedException();
        public IQueryable<PersonnelModel> Table => _personnelList.AsQueryable();
        public IQueryable<PersonnelModel> TableNoTracking => throw new NotImplementedException();

        public void Add(PersonnelModel entity, bool saveNow = true)
        {
            _personnelList.Add(entity);
        }

        public void Delete(PersonnelModel entity, bool saveNow = true)
        {
            var existing = _personnelList.FirstOrDefault(a => a.Id == entity.Id);
            _personnelList.Remove(existing);
        }

        public void Update(PersonnelModel entity, bool saveNow = true)
        {
            var existing = _personnelList.FirstOrDefault(a => a.Id == entity.Id);
            existing.Name = entity.Name;
            existing.Phone = entity.Phone;
            existing.Age = entity.Age;
            _personnelList.Add(existing);
        }

        public List<PersonnelModel> GetAll()
        {
            return _personnelList;
        }
    }
}
