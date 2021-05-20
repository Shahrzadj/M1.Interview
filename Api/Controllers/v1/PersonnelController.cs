using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Personnel.Data.Contracts;


namespace Personnel.Api.Controllers.v1
{
    [ApiController]
    //[Route("api/v1/[controller]")]
    public class PersonnelController : ControllerBase
    {
        private readonly IPersonnelRepository _personnelRepository;
        public PersonnelController(IPersonnelRepository personnelRepository)
        {
            _personnelRepository = personnelRepository;
        }
        [Route("api/v1/[controller]/getall")]
        [HttpGet]
        public async Task<IActionResult> GetPersonnelList(CancellationToken cancellationToken)
        {
            var personnel = await _personnelRepository.TableNoTracking.ToListAsync(cancellationToken);
            return Ok(personnel);
        }
        // DELETE api/values/5
        [Route("api/v1/[controller]/getall")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var itemToDelete =  _personnelRepository.GetById(new {id});
            _personnelRepository.Delete(itemToDelete);
        }
    }
}
