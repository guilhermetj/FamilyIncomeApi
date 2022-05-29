using AutoFixture;
using FamilyIncomeApi.Controllers;
using FamilyIncomeApi.Models.Dtos.CategoryDtos;
using FamilyIncomeApi.Models.Entities;
using FamilyIncomeApi.Services.Interfaces;
using FamilyIncomeTestes.Factories.Controllers;
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
        private CategoryControllerFactory _factory;
        private Mock<ICategoryService> _serviceMock;

        public CategoryControllerTest()
        {
            _fixture = new Fixture();
            _factory = new CategoryControllerFactory();
            _serviceMock = new Mock<ICategoryService>();
        }
        [Fact]
        public async void TestChamadaGet200()
        {
            
            var categorias = _fixture.CreateMany<CategoryDetailsDto>();

            var requisicao = _factory.BuscaCategorias(categorias)
                                     .Controller();

            var result = (OkObjectResult)await requisicao.Get();

            result.StatusCode.Should().Be(200);

            Assert.NotNull(result.Value);

        }
        [Fact]
        public async void TestChamadaGet204()
        {

            var requisicao = _factory.BuscaCategorias(new List<CategoryDetailsDto>())
                                     .Controller();

            var result = (NoContentResult)await requisicao.Get();

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

            var factory = _factory.CriaCategorias(categoria).Controller();
            var result = (OkObjectResult)await factory.Create(categoria);

            result.StatusCode.Should().Be(200);
        }

    }
}
