using System;
using System.Linq;
using System.Threading;
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

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var sales = await _salesRepository.TableNoTracking.ToListAsync(cancellationToken);
            return Ok(sales);
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

        [HttpPut]
        public void Update(SalesDto salesDto)
        {
            var itemToUpdate = _salesRepository.Table.FirstOrDefault(p => p.Id == salesDto.Id);
            if (itemToUpdate != null)
            {
                itemToUpdate.PersonnelId = salesDto.PersonnelId;
                itemToUpdate.ReportDate = salesDto.ReportDate;
                itemToUpdate.SalesAmount = salesDto.SalesAmount;
                _salesRepository.Update(itemToUpdate);
            }
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
