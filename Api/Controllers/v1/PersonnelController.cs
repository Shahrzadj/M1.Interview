﻿using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Personnel.Common.Dtos.Personnel;
using Personnel.Data.Contracts;
using Personnel.Entities.Personnel;


namespace Personnel.Api.Controllers.v1
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonnelController : ControllerBase
    {
        private readonly IPersonnelRepository _personnelRepository;
        public PersonnelController(IPersonnelRepository personnelRepository)
        {
            _personnelRepository = personnelRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var personnel = await _personnelRepository.TableNoTracking.ToListAsync(cancellationToken);
            return Ok(personnel);
        }

        [HttpPost]
        public void Add(PersonnelDto personnelDto)
        {
            _personnelRepository.Add(new PersonnelModel()
            {
                Name = personnelDto.Name,
                Age = personnelDto.Age,
                Phone = personnelDto.Phone
            });
        }

        [HttpPut]
        public void Update(PersonnelDto personnelDto)
        {
            var itemToUpdate =  _personnelRepository.Table.FirstOrDefault(p=>p.Id==personnelDto.Id);
            if (itemToUpdate != null)
            {
                itemToUpdate.Name = personnelDto.Name;
                itemToUpdate.Age = personnelDto.Age;
                itemToUpdate.Phone = personnelDto.Phone;
                _personnelRepository.Update(itemToUpdate);
            }
        }

        [HttpDelete]
        [AllowAnonymous]
        public void Delete(int id)
        {
            var itemToDelete =  _personnelRepository.Table.FirstOrDefault(p=>p.Id==id);;
            if (itemToDelete != null)
            {
                _personnelRepository.Delete(itemToDelete);
            }
        }
    }
}