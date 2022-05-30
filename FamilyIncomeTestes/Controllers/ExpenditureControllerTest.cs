using AutoFixture;
using FamilyIncomeApi.Models.Dtos.ExpenditureDtos;
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
    public class ExpenditureControllerTest
    {
        private Fixture _fixture;
        private ExpenditureControllerFactory _factory;

        public ExpenditureControllerTest()
        {
            _fixture = new Fixture();
            _factory = new ExpenditureControllerFactory();
        }
        [Fact]
        public async void TestChamadaGet200()
        {
            var resume = _fixture.CreateMany<ExpenditureDto>();
            var paramsExpenditure = _fixture.Create<ExpenditureParams>();

            var requisicao = _factory.BuscaDespesas(resume, paramsExpenditure)
                                     .Controller();

            var result = (OkObjectResult)await requisicao.Get(paramsExpenditure);

            result.StatusCode.Should().Be(200);

            Assert.NotNull(result.Value);
        }
        [Fact]
        public async void TestChamadaGet204()
        {
            var resume = _fixture.CreateMany<ExpenditureDto>();
            var paramsExpenditure = _fixture.Create<ExpenditureParams>();

            var requisicao = _factory.BuscaDespesas(resume, paramsExpenditure)
                                     .Controller();

            var result = (NoContentResult)await requisicao.Get(new ExpenditureParams());

            result.StatusCode.Should().Be(204);
        }
        [Fact]
        public async void TestChamadaGetbyId200()
        {
            var resume = _fixture.Create<ExpenditureDetailsDto>(); 
            var requisicao = _factory.BuscaDespesasPeloId(resume)
                                     .Controller();

            var result = (OkObjectResult)await requisicao.GetById(1);

            result.StatusCode.Should().Be(200);
        }
        [Fact]
        public async void TestChamadaGetbyId404()
        {
            var resume = _fixture.Create<ExpenditureDetailsDto>();
            var requisicao = _factory.BuscaDespesasPeloId(resume)
                                     .Controller();

            var result = (NotFoundObjectResult)await requisicao.GetById(4);

            result.StatusCode.Should().Be(404);
        }

        [Fact]
        public async void TestChamadaGetbyAnoMes200()
        {
            var resume = _fixture.CreateMany<ExpenditureDetailsDto>();
            var requisicao = _factory.BuscaDespesasPeloAnoMes(resume)
                                     .Controller();

            var result = (OkObjectResult)await requisicao.GetByMonth(2022, 5);

            result.StatusCode.Should().Be(200);
        }
        [Fact]
        public async void TestChamadaGetbyAnoMes204()
        {
            var resume = _fixture.CreateMany<ExpenditureDetailsDto>();
            var requisicao = _factory.BuscaDespesasPeloAnoMes(resume)
                                     .Controller();

            var result = (NoContentResult)await requisicao.GetByMonth(666, 222);

            result.StatusCode.Should().Be(204);
        }
        [Fact]
        public async void TestChamadaCreate200()
        {
            var resume = _fixture.Create<ExpenditureCreateDto>();
            var factory = _factory.CriarDespesa(resume)
                                     .Controller();

            var result = (OkObjectResult)await factory.Add(resume);

            result.StatusCode.Should().Be(200);
        }
        [Fact]
        public async void TestChamadaUpdate200()
        {
            var resume = _fixture.Create<ExpenditureUpdateDto>();
            var factory = _factory.AlteraDespesaS(resume)
                                     .Controller();

            var result = (OkObjectResult)await factory.Edit(1, resume);

            result.StatusCode.Should().Be(200);
        }
        [Fact]
        public async void TestChamadaUpdate404()
        {
            var resume = _fixture.Create<ExpenditureUpdateDto>();
            var factory = _factory.AlteraDespesaS(resume)
                                     .Controller();

            var result = (BadRequestObjectResult)await factory.Edit(3, resume);

            result.StatusCode.Should().Be(400);
        }
        [Fact]
        public async void TestChamadaDelete200()
        {
            var resume = _fixture.Create<ExpenditureDto>();
            var factory = _factory.DeletaDespesa(resume)
                                     .Controller();

            var result = (OkObjectResult)await factory.Delete(1);

            result.StatusCode.Should().Be(200);
        }
        [Fact]
        public async void TestChamadaDelete400()
        {
            var resume = _fixture.Create<ExpenditureDto>();
            var factory = _factory.DeletaDespesa(resume)
                                     .Controller();

            var result = (BadRequestObjectResult)await factory.Delete(3);

            result.StatusCode.Should().Be(400);
        }

    }
}
