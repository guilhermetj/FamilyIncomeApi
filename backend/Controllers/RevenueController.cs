using AutoMapper;
using FamilyIncomeApi.Data.Dtos.RevenueDtos;
using FamilyIncomeApi.Models.Entities;
using FamilyIncomeApi.Models.Params;
using FamilyIncomeApi.Repository.Interfaces;
using FamilyIncomeApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FamilyIncomeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RevenueController : ControllerBase
    {
        private readonly IRevenueService _service;

        public RevenueController(IRevenueService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]RevenueParams revenueParams)
        {
            var revenue = await _service.Get(revenueParams);

            return revenue.Any()
                                ? Ok(revenue)
                                : NoContent();
        }
        [HttpGet("{year}/{month}")]
        public async Task<IActionResult> GetByMonth(int year, int month)
        {
            var revenue = await _service.GetByMonth(year, month);

            return revenue.Any()
                               ? Ok(revenue)
                               : NoContent();

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var revenue = await _service.GetById(id);

            return revenue != null ? Ok(revenue) : NotFound("Receita não encontrada");
        }
        [HttpPost]
        public async Task<IActionResult> Add(RevenueCreateDto request)
        {
            return await _service.Create(request) ? Ok("Criado com sucesso") : BadRequest("Error ao criar");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, RevenueUpdateDto request)
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
