using System;
using System.Collections.Generic;
using System.Globalization;
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
                ReportDate =new DateTime(salesDto.Year,salesDto.Month,salesDto.Day),
                SalesAmount = salesDto.SalesAmount
            });
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id, int month, int year)
        {
            List<string> labelDataset=new List<string>();
            List<decimal> SaleAmountsDataset = new List<decimal>();
            var monthName = "";
            decimal saleAmount=decimal.Zero;
            var salesListForSpecificPerson =await _salesRepository.Table.Where(p => p.PersonnelId == id && p.ReportDate.Value.Month==month && p.ReportDate.Value.Year==year).OrderBy(s => s.ReportDate).ToListAsync();
            if (salesListForSpecificPerson.Any())
            {
                monthName = salesListForSpecificPerson[0].ReportDate.Value.ToMonthName();
                int days = DateTime.DaysInMonth(year, month);
                for (int day = 1; day <= days; day++)
                {
                    saleAmount = decimal.Zero;
                    if (salesListForSpecificPerson.Any(d => d.ReportDate.Value.Day == day))
                    {
                        var item = salesListForSpecificPerson.FirstOrDefault(d => d.ReportDate.Value.Day == day);
                        saleAmount = item.SalesAmount.Value;
                    }
                    labelDataset.Add(day.ToString());
                    SaleAmountsDataset.Add(saleAmount);
                }
            }
            return Ok(new
            {
                Labelset = labelDataset,
                dataset = SaleAmountsDataset,
                monthName = monthName
            });
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
static class DateTimeExtensions
{
    public static string ToMonthName(this DateTime dateTime)
    {
        return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dateTime.Month);
    }
}