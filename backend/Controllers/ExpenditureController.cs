using FamilyIncomeApi.Models.Entities;
using FamilyIncomeApi.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FamilyIncomeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExpenditureController : ControllerBase
    {
        private readonly IExpenditureRepository _repository;
        public ExpenditureController(IExpenditureRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var expenditure = await _repository.Get();

            return expenditure.Any() ? Ok(expenditure) : NoContent();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var expenditureBanco = await _repository.GetById(id);
            if (expenditureBanco == null) return BadRequest("Error ao encontrar despesas");

            return Ok(expenditureBanco);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Expenditure expenditure)
        {
            var expenditureCreate = new Expenditure
            {
                Description = expenditure.Description,
                Value = expenditure.Value,
                Date = expenditure.Date,
            };
            _repository.Create(expenditureCreate);

            return await _repository.SaveChangesAsync() ? Ok("Criado com sucesso") : BadRequest("Error ao criar");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, Expenditure expenditure)
        {
            var expenditureBanco = await _repository.GetById(id);
            if (expenditureBanco == null) return BadRequest("Error ao encontrar despesas");

            expenditureBanco.Description = expenditure.Description;
            expenditureBanco.Value = expenditure.Value;
            expenditureBanco.Date = expenditure.Date;

            _repository.Update(expenditureBanco);

            return await _repository.SaveChangesAsync() ? Ok("Editado com sucesso") : BadRequest("Error ao Editar");
        }
        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var expenditureBanco = await _repository.GetById(id);
            if (expenditureBanco == null) return BadRequest("Error ao encontrar despesas");

            _repository.Delete(expenditureBanco);

            return await _repository.SaveChangesAsync() ? Ok("Deletado com sucesso") : BadRequest("Error ao Deletar");
        }
    }
}
