using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
            var okResult = _controller.Get(1).Result as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<decimal>>(okResult.Value);
            var countOfitems = items.Count();
            Assert.Equal(12, countOfitems);
        }
        //[Fact]
        //public void GetById_UnknownIdPassed_ReturnsNoContentResult()
        //{
        //    // Act
        //    var result = _controller.Get(4).Result;

        //    // Assert
        //    Assert.IsType<BadRequestObjectResult>(result);
        //}
        [Fact]
        public void Add_ValidObject_OneItemMustAdded()
        {
            // Arrange
            var newSale = new SalesDto()
            {
                SalesAmount = 20,
                ReportDate = DateTime.Now,
                PersonnelId = 1,
                 Id=10
            };
            // Act
            _controller.Add(newSale);

            // Assert
            Assert.Equal(3, _repository.Table.Count());
        }


    
    }
}
