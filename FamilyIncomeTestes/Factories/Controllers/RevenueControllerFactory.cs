using FamilyIncomeApi.Controllers;
using FamilyIncomeApi.Data.Dtos.RevenueDtos;
using FamilyIncomeApi.Models.Params;
using FamilyIncomeApi.Services.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyIncomeTestes.Factories.Controllers
{
    public class RevenueControllerFactory
    {
        private readonly Mock<IRevenueService> _revenueService;
        public RevenueControllerFactory()
        {
            _revenueService = new Mock<IRevenueService>();
        }
        public RevenueControllerFactory BuscaReceitas(IEnumerable<RevenueDto> revenues, RevenueParams revenueParams)
        {

            _revenueService.Setup(x => x.Get(revenueParams)).ReturnsAsync(revenues);

            return this;
        }
        public RevenueControllerFactory BuscaReceitasPeloId(RevenueDetailsDto revenues)
        {
            _revenueService.Setup(x => x.GetById(1)).ReturnsAsync(revenues);

            return this;
        }
        public RevenueControllerFactory BuscaReceitasPeloAnoMes(IEnumerable<RevenueDetailsDto> revenues)
        {
            _revenueService.Setup(x => x.GetByMonth(2022, 5)).ReturnsAsync(revenues);

            return this;
        }
        public RevenueControllerFactory CriarReceita(RevenueCreateDto revenues)
        {
            _revenueService.Setup(x => x.Create(revenues)).ReturnsAsync(true);
            return this;
        }
        public RevenueControllerFactory AlteraReceita(RevenueUpdateDto revenues)
        {
            _revenueService.Setup(x => x.Update(1, revenues)).ReturnsAsync(true);
            return this;
        }
        public RevenueControllerFactory DeletaReceita(RevenueDto revenues)
        {
            _revenueService.Setup(x => x.Delete(1)).ReturnsAsync(true);
            return this;
        }
        public RevenueController Controller()
        {
            return new RevenueController(_revenueService.Object);
        }
    }
}
