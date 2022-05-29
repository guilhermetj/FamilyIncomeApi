using FamilyIncomeApi.Repository.Interfaces;
using FamilyIncomeApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FamilyIncomeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResumeController : ControllerBase
    {

        private readonly IResumeService _service;
        public ResumeController(IResumeService service)
        {
            _service = service;
        }

        [HttpGet("{year}/{month}")]
        public async Task<IActionResult> Get(int year, int month)
        {
            var resume = await _service.GetResume(year, month);

            return resume != null ? Ok(resume) : NotFound("Resumo não encontrado");
        }
    }
}
