using AutoMapper;
using FamilyIncomeApi.Models.Dtos.ExpenditureDtos;
using FamilyIncomeApi.Models.Entities;
using FamilyIncomeApi.Models.Params;
using FamilyIncomeApi.Repository.Interfaces;
using FamilyIncomeApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FamilyIncomeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExpenditureController : ControllerBase
    {
        private readonly IExpenditureService _service;
        public ExpenditureController(IExpenditureService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]ExpenditureParams expenditureParams)
        {
            var expenditures = await _service.Get(expenditureParams);

            return expenditures.Any()
                                ? Ok(expenditures)
                                : NoContent();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var expenditure = await _service.GetById(id);

            return expenditure != null ? Ok(expenditure) : NotFound("Despesa não encontrada");
        }
        [HttpGet("{year}/{month}")]
        public async Task<IActionResult> GetByMonth(int year, int month)
        {
            var expenditure = await _service.GetByMonth(year, month);

            return expenditure.Any()
                               ? Ok(expenditure)
                               : NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> Add(ExpenditureCreateDto request)
        {
            return await _service.Create(request) ? Ok("Criado com sucesso") : BadRequest("Error ao criar");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, ExpenditureUpdateDto request)
        {
            return await _service.Update(id, request) ? Ok("Editado com sucesso") : BadRequest("Error ao Editar");
        }
        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            return await _service.Delete(id) ? Ok("Deletado com sucesso") : BadRequest("Error ao Deletar");
        }
    }
}
