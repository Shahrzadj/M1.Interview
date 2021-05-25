using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Sales.Api.Controllers;
using Sales.Api.Test.FakeRepository;
using Sales.Common.Dtos.Sales;
using Sales.Data.Contracts;
using Xunit;

namespace Sales.Api.Test
{
    public class SalesTestController
    {
        SalesController _controller;
        ISalesRepository _repository;
        private readonly ISalesRepository _salesRepository;
        public SalesTestController()
        {
            _repository = new SalesFakeRepository();
            _controller = new SalesController(_repository);
        }

        [Fact]
        public void GetById_WhenCalled_ReturnsAllItemsForOnePerson()
        {
            // Act
            var okResult = _controller.Get(1,05,2021).Result as OkObjectResult;
           // Assert
            Assert.IsType<SalesListInChartDto>(okResult.Value);
        }
       
        [Fact]
        public void Add_ValidObject_OneItemMustAdded()
        {
            // Arrange
            var newSale = new SalesDto()
            {
                SalesAmount = 20,
                ReportDate = DateTime.Now,
                PersonnelId = 1,
                Id = 10,
                Year = 2020,
                Month = 5,
                Day = 25
            };
            // Act
            _controller.Add(newSale);

            // Assert
            Assert.Equal(3, _repository.Table.Count());
        }



    }
}
