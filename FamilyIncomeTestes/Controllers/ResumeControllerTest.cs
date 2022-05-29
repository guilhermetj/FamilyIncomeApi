using AutoFixture;
using FamilyIncomeApi.Models.Dtos.ResumeDtos;
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
    public class ResumeControllerTest
    {
        private Fixture _fixture;
        private ResumeControllerFactory _factory;

        public ResumeControllerTest()
        {
            _fixture = new Fixture();
            _factory = new ResumeControllerFactory();
        }
        [Fact]
        public async void TestChamadaGetResume200()
        {

            var resume = _fixture.Create<ResumeDto>();

            var requisicao = _factory.BuscaResumo(resume)
                                     .Controller();

            var result = (OkObjectResult)await requisicao.Get(2022, 5);

            result.StatusCode.Should().Be(200);

            Assert.NotNull(result.Value);

        }
    }
}
