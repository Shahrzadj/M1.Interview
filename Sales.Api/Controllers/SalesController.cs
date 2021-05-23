using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var data =await _salesRepository.Table.Where(p => p.PersonnelId == id).OrderBy(s=>s.ReportDate).Select(k => new { k.ReportDate.Value, k.SalesAmount })
                .GroupBy(x => new { x.Value.Month }, (key, group) => new
                {
                    month = key.Month,
                    amount = group.Sum(k => k.SalesAmount).Value
                }).ToListAsync(); ;
            var salesAmountList=new List<decimal>();
            for (int i = 1; i <= 12; i++)
            {
                if (data.All(d => d.month != i))
                {
                    data.Add(new { month = i, amount = decimal.Zero });
                }
            }
            foreach (var item in data.OrderBy(d=>d.month))
            {
                salesAmountList.Add(item.amount);
            }
            return Ok(salesAmountList);
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
