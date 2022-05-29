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
            var requisicao = _factory.BuscaCategoriasPeloId(new CategoryDetailsDto())
                                     .Controller();

            var result = (OkObjectResult)await requisicao.GetById(1);

            result.StatusCode.Should().Be(200);

        }
        [Fact]
        public async void TestChamadaGetById404()
        {

            var requisicao = _factory.BuscaCategoriasPeloId(new CategoryDetailsDto())
                                      .Controller();

            var result = (NotFoundObjectResult)await requisicao.GetById(2);

            result.StatusCode.Should().Be(404);

        }

        [Fact]
        public async void TestChamadaCreate200()
        {
            var categoria = _fixture.Create<CategoryDto>();

            var factory = _factory.CriaCategorias(categoria).Controller();
            var result = (OkObjectResult)await factory.Create(categoria);

            result.StatusCode.Should().Be(200);
        }
        [Fact]
        public async void TestChamadaUpdate200()
        {
            var categoria = _fixture.Create<CategoryDto>();

            var factory = _factory.AlteraCategorias(categoria).Controller();
            var result = (OkObjectResult)await factory.Update(1, categoria);

            result.StatusCode.Should().Be(200);
        }
        [Fact]
        public async void TestChamadaUpdate400()
        {

            var factory = _factory.AlteraCategorias(new CategoryDto()).Controller();
            var result = (BadRequestObjectResult)await factory.Update(2, new CategoryDto());

            result.StatusCode.Should().Be(400);
        }
        [Fact]
        public async void TestChamadaDelete200()
        {

            var factory = _factory.DeletaCategorias(new CategoryDto()).Controller();
            var result = (OkObjectResult)await factory.Delete(1);

            result.StatusCode.Should().Be(200);
        }
        [Fact]
        public async void TestChamadaDelete400()
        {

            var factory = _factory.DeletaCategorias(new CategoryDto()).Controller();
            var result = (BadRequestObjectResult)await factory.Delete(3);

            result.StatusCode.Should().Be(400);
        }


    }
}
