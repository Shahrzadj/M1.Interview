using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sales.Common.Dtos.Sales;
using Sales.Data.Contracts;


namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesRepository _salesRepository;
        public SalesController(ISalesRepository salesRepository)
        {
            _salesRepository = salesRepository;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        //{
        //    var sales = await _salesRepository.TableNoTracking.ToListAsync(cancellationToken);
        //    return Ok(sales);
        //}

        [HttpPost]
        public void Add(SalesDto salesDto)
        {
            _salesRepository.Add(new Entities.Sales.Sales()
            {
                PersonnelId = salesDto.PersonnelId,
                ReportDate = new DateTime(),
                SalesAmount = salesDto.SalesAmount
            });
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var itemToUpdate =await _salesRepository.Table.Where(p => p.PersonnelId == id).OrderBy(s=>s.ReportDate).ToListAsync();
            //var grouped = (from p in itemToUpdate
            //               group p by new { month = p.ReportDate.Value.Month } into d
            //    select new { count = d.Count() });
           
            var data = itemToUpdate.Select(k => new {  k.ReportDate.Value, k.SalesAmount })
                .GroupBy(x => new {  x.Value.Month }, (key, group) => new
            {
                mnth = key.Month,
                tCharge = group.Sum(k => k.SalesAmount).Value
            }).ToList();
            var c=new List<decimal>();
            for (int i = 1; i <= 12; i++)
            {
                if (!data.Any(d => d.mnth == i))
                {
                    decimal a = decimal.Zero;
                    data.Add(new { mnth = i, tCharge = a });
                }
            }

            foreach (var item in data.OrderBy(d=>d.mnth))
            {
                c.Add(item.tCharge);
            }
            return Ok(c);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            var itemToDelete = _salesRepository.Table.FirstOrDefault(p => p.Id == id); ;
            if (itemToDelete != null)
            {
                _salesRepository.Delete(itemToDelete);
            }
        }
    }
}
