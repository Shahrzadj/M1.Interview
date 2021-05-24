using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Personnel.Api.Controllers;
using Personnel.Api.Test.FakeRepository;
using Personnel.Common.Dtos.Personnel;
using Personnel.Data.Contracts;
using Personnel.Entities.Personnel;
using Xunit;

namespace Personnel.Api.Test
{
    public class PersonnelTestController
    {
        PersonnelController _controller;
        IPersonnelRepository _repository;
        private readonly IPersonnelRepository _personnelRepository;
        public PersonnelTestController()
        {
            _repository = new PersonnelFakeRepository();
            _controller = new PersonnelController(_repository);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.GetAll(cancellationToken:CancellationToken.None).Result as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<PersonnelModel>>(okResult.Value);
            var countOfPersonnel = items.Count();
            Assert.Equal(2, countOfPersonnel);
        }

        [Fact]
        public void Add_ValidObject_OneItemMustAdded()
        {
            // Arrange
            var newPerson = new PersonnelDto()
            {
                Name = "Sam",
                Phone = "00989197558635",
                Age =42,
                 Id=10
            };
            // Act
            _controller.Add(newPerson);

            // Assert
            Assert.Equal(3, _repository.GetAll().Count());
        }


        [Fact]
        public void Edit_ValidObject_OneItemMustEdited()
        {
            // Arrange
            var person = new PersonnelDto()
            {
                Id = 1,
                Name = "Shahrzad",
                Phone = "+989197759577",
                Age = 50
            };

            // Act
            _controller.Update(person);

            // Assert
            var editedperson = _repository.Table.FirstOrDefault(r=>r.Id==1);
            if (editedperson != null) Assert.Equal("Shahrzad", editedperson.Name);
        }
    }
}
