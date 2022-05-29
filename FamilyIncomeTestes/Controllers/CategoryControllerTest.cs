using AutoFixture;
using FamilyIncomeApi.Controllers;
using FamilyIncomeApi.Models.Dtos.CategoryDtos;
using FamilyIncomeApi.Models.Entities;
using FamilyIncomeApi.Services.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace FamilyIncomeTestes.Controllers
{
    public class CategoryControllerTest
    {
        private Fixture _fixture;
        public CategoryControllerTest()
        {
            _fixture = new Fixture();
        }
        [Fact]
        public async void TestChamadaGet200()
        {
            
            var categorias = _fixture.CreateMany<CategoryDetailsDto>();

            var serviceMock = new Mock<ICategoryService>();
            serviceMock.Setup(x => x.Get()).ReturnsAsync(categorias);


            var controller = new CategoryController(serviceMock.Object);

            var result = (OkObjectResult)await controller.Get();

            result.StatusCode.Should().Be(200);

        }
        [Fact]
        public async void TestChamadaGet204()
        {
            var serviceMock = new Mock<ICategoryService>();
            serviceMock.Setup(x => x.Get()).ReturnsAsync(new List<CategoryDetailsDto>());

            var controller = new CategoryController(serviceMock.Object);

            var result = (NoContentResult)await controller.Get();

            result.StatusCode.Should().Be(204);
        }
        [Fact]
        public async void TestChamadaGetById200()
        {

            var serviceMock = new Mock<ICategoryService>();
            serviceMock.Setup(x => x.GetById(1)).ReturnsAsync(new CategoryDetailsDto());


            var controller = new CategoryController(serviceMock.Object);

            var result = (OkObjectResult)await controller.GetById(1);

            result.StatusCode.Should().Be(200);

        }
        [Fact]
        public async void TestChamadaGetById204()
        {

            var categorias = _fixture.Create<CategoryDetailsDto>();

            var serviceMock = new Mock<ICategoryService>();
            serviceMock.Setup(x => x.GetById(1)).ReturnsAsync(categorias);


            var controller = new CategoryController(serviceMock.Object);

            var result = (OkObjectResult)await controller.GetById(1);

            result.StatusCode.Should().Be(200);

        }

        [Fact]
        public async void TestCreate200()
        {
            var categoria = _fixture.Create<CategoryDto>();

            var serviceMock = new Mock<ICategoryService>();
            serviceMock.Setup(x => x.Create(categoria)).ReturnsAsync(true);

            var controller = new CategoryController(serviceMock.Object);

            var result = (OkObjectResult)await controller.Create(categoria);

            result.StatusCode.Should().Be(200);
        }

    }
}
