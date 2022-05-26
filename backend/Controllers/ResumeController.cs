using FamilyIncomeApi.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FamilyIncomeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResumeController : ControllerBase
    {
        private readonly IResumeRepository _repository;

        public ResumeController(IResumeRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("{year}/{month}")]
        public async Task<IActionResult> Get(int year, int month)
        {
            var resume = await _repository.GetResume(year, month);
            return Ok(resume);
        }
    }
}
