using FamilyIncomeApi.Controllers;
using FamilyIncomeApi.Data.Dtos.ExpenditureDtos;
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
    public class ExpenditureControllerFactory
    {
        private readonly Mock<IExpenditureService> _expenditureService;
        public ExpenditureControllerFactory()
        {
            _expenditureService = new Mock<IExpenditureService>();
        }
        public ExpenditureControllerFactory BuscaDespesas(IEnumerable<ExpenditureDto> expenditures, ExpenditureParams expenditureParams)
        {

            _expenditureService.Setup(x => x.Get(expenditureParams)).ReturnsAsync(expenditures);

            return this;
        }
        public ExpenditureControllerFactory BuscaDespesasPeloId(ExpenditureDetailsDto expenditure)
        {
            _expenditureService.Setup(x => x.GetById(1)).ReturnsAsync(expenditure);

            return this;
        }
        public ExpenditureControllerFactory BuscaDespesasPeloAnoMes(IEnumerable<ExpenditureDetailsDto> expenditures)
        {
            _expenditureService.Setup(x => x.GetByMonth(2022, 5)).ReturnsAsync(expenditures);

            return this;
        }
        public ExpenditureControllerFactory CriarDespesa(ExpenditureCreateDto expenditure)
        {
            _expenditureService.Setup(x => x.Create(expenditure)).ReturnsAsync(true);
            return this;
        }
        public ExpenditureControllerFactory AlteraDespesaS(ExpenditureUpdateDto expenditure)
        {
            _expenditureService.Setup(x => x.Update(1, expenditure)).ReturnsAsync(true);
            return this;
        }
        public ExpenditureControllerFactory DeletaDespesa(ExpenditureDto expenditure)
        {
            _expenditureService.Setup(x => x.Delete(1)).ReturnsAsync(true);
            return this;
        }
        public ExpenditureController Controller()
        {
            return new ExpenditureController(_expenditureService.Object);
        }
    }
}
