using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Sales.Data.Contracts;

namespace Sales.Api.Test.FakeRepository
{
    public class SalesFakeRepository:ISalesRepository
    {
        private readonly List<Entities.Sales.Sales> _salesList;

        public SalesFakeRepository()
        {
            _salesList = new List<Entities.Sales.Sales>()
            {
                new Entities.Sales.Sales(){Id = 1,ReportDate = DateTime.Now,SalesAmount = 20,PersonnelId = 1},
                new Entities.Sales.Sales(){Id = 2,ReportDate = DateTime.Now,SalesAmount = 30,PersonnelId = 2},
            };
        }
        public DbSet<Entities.Sales.Sales> Entities => throw new NotImplementedException();
        public IQueryable<Entities.Sales.Sales> Table => _salesList.AsQueryable();
        public IQueryable<Entities.Sales.Sales> TableNoTracking => throw new NotImplementedException();
        public void Add(Entities.Sales.Sales entity, bool saveNow = true)
        {
            _salesList.Add(entity);
        }

        public void Delete(Entities.Sales.Sales entity, bool saveNow = true)
        {
            var existing = _salesList.FirstOrDefault(a => a.Id == entity.Id);
            _salesList.Remove(existing);
        }

        public void Update(Entities.Sales.Sales entity, bool saveNow = true)
        {
            var existing = _salesList.FirstOrDefault(a => a.Id == entity.Id);
            existing.SalesAmount = entity.SalesAmount;
            existing.ReportDate = entity.ReportDate;
            existing.PersonnelId = entity.PersonnelId;
            _salesList.Add(existing);
        }
    }
}
