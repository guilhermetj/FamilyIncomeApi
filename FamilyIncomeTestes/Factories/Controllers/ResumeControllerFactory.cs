using FamilyIncomeApi.Controllers;
using FamilyIncomeApi.Models.Dtos.ResumeDtos;
using FamilyIncomeApi.Services.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyIncomeTestes.Factories.Controllers
{
    internal class ResumeControllerFactory
    {
        private readonly Mock<IResumeService> _resumeService;
        public ResumeControllerFactory()
        {
            _resumeService = new Mock<IResumeService>();
        }
        public ResumeControllerFactory BuscaResumo(ResumeDto resume)
        {

            _resumeService.Setup(x => x.GetResume(2022, 5)).ReturnsAsync(resume);

            return this;
        }
        public ResumeController Controller()
        {
            return new ResumeController(_resumeService.Object);
        }
    }
}
