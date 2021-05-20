using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Personnel.Data.Contracts;


namespace Personnel.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PersonnelController : ControllerBase
    {
        private readonly IPersonnelRepository _personnelRepository;
        public PersonnelController(IPersonnelRepository personnelRepository)
        {
            _personnelRepository = personnelRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var personnel = await _personnelRepository.TableNoTracking.ToListAsync(cancellationToken);
            return Ok(personnel);
        }

    }
}
