using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var personnel = await _salesRepository.TableNoTracking.ToListAsync(cancellationToken);
            return Ok(personnel);
        }

    }
}
