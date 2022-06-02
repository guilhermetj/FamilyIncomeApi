using AutoFixture;
using FamilyIncomeApi.Data.Dtos.RevenueDtos;
using FamilyIncomeApi.Models.Params;
using FamilyIncomeTestes.Factories.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FamilyIncomeTestes.Controllers
{
    public class RevenueControllerTest
    {
        private Fixture _fixture;
        private RevenueControllerFactory _factory;

        public RevenueControllerTest()
        {
            _fixture = new Fixture();
            _factory = new RevenueControllerFactory();
        }
        [Fact]
        public async void TestChamadaGet200()
        {

            var revenue = _fixture.CreateMany<RevenueDto>();
            var paramsRevenue = _fixture.Create<RevenueParams>();

            var requisicao = _factory.BuscaReceitas(revenue, paramsRevenue)
                                     .Controller();

            var result = (OkObjectResult)await requisicao.Get(paramsRevenue);

            result.StatusCode.Should().Be(200);

            Assert.NotNull(result.Value);
        }
        [Fact]
        public async void TestChamadaGet204()
        {

            var revenue = _fixture.CreateMany<RevenueDto>();
            var paramsRevenue = _fixture.Create<RevenueParams>();

            var requisicao = _factory.BuscaReceitas(revenue, paramsRevenue)
                                     .Controller();

            var result = (NoContentResult)await requisicao.Get(new RevenueParams());

            result.StatusCode.Should().Be(204);

        }
        [Fact]
        public async void TestChamadaGetById200()
        {

            var revenue = _fixture.Create<RevenueDetailsDto>();

            var requisicao = _factory.BuscaReceitasPeloId(revenue)
                                     .Controller();

            var result = (OkObjectResult)await requisicao.GetById(1);

            result.StatusCode.Should().Be(200);

        }
        [Fact]
        public async void TestChamadaGetById204()
        {

            var revenue = _fixture.Create<RevenueDetailsDto>();

            var requisicao = _factory.BuscaReceitasPeloId(revenue)
                                     .Controller();

            var result = (NotFoundObjectResult)await requisicao.GetById(5);

            result.StatusCode.Should().Be(404);

        }
        [Fact]
        public async void TestChamadaCreate200()
        {
            var revenue = _fixture.Create<RevenueCreateDto>();
            var factory = _factory.CriarReceita(revenue)
                                     .Controller();

            var result = (OkObjectResult)await factory.Add(revenue);

            result.StatusCode.Should().Be(200);
        }
        [Fact]
        public async void TestChamadaUpdate200()
        {
            var revenue = _fixture.Create<RevenueUpdateDto>();
            var factory = _factory.AlteraReceita(revenue)
                                     .Controller();

            var result = (OkObjectResult)await factory.Edit(1, revenue);

            result.StatusCode.Should().Be(200);
        }
        [Fact]
        public async void TestChamadaUpdate404()
        {
            var revenue = _fixture.Create<RevenueUpdateDto>();
            var factory = _factory.AlteraReceita(revenue)
                                     .Controller();

            var result = (BadRequestObjectResult)await factory.Edit(3, revenue);

            result.StatusCode.Should().Be(400);
        }
        [Fact]
        public async void TestChamadaDelete200()
        {
            var revenue = _fixture.Create<RevenueDto>();
            var factory = _factory.DeletaReceita(revenue)
                                     .Controller();

            var result = (OkObjectResult)await factory.Delete(1);

            result.StatusCode.Should().Be(200);
        }
        [Fact]
        public async void TestChamadaDelete400()
        {
            var revenue = _fixture.Create<RevenueDto>();
            var factory = _factory.DeletaReceita(revenue)
                                     .Controller();

            var result = (BadRequestObjectResult)await factory.Delete(3);

            result.StatusCode.Should().Be(400);
        }
        [Fact]
        public async void TestChamadaGetByMonth200()
        {
            var revenue = _fixture.CreateMany<RevenueDetailsDto>();
            var factory = _factory.BuscaReceitasPeloAnoMes(revenue)
                                     .Controller();

            var result = (OkObjectResult)await factory.GetByMonth(2022, 5);

            result.StatusCode.Should().Be(200);
        }
        [Fact]
        public async void TestChamadaGetByMonth204()
        {
            var revenue = _fixture.CreateMany<RevenueDetailsDto>();

            var factory = _factory.BuscaReceitasPeloAnoMes(revenue)
                                     .Controller();

            var result = (NoContentResult)await factory.GetByMonth(666, 222);

            result.StatusCode.Should().Be(204);
        }
    }
}
