using AutoMapper;
using FamilyIncomeApi.Data.Dtos.CategoryDtos;
using FamilyIncomeApi.Models.Entities;
using FamilyIncomeApi.Repository.Interfaces;
using FamilyIncomeApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FamilyIncomeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var category = await _service.Get();

            return category.Any()
                                ? Ok(category)
                                : NoContent();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _service.GetById(id);

            return category != null ? Ok(category) : NotFound("Categoria não encontrada");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto request)
        {
            return await _service.Create(request) ? Ok("Criado com sucesso") : BadRequest("Error ao criar");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CategoryDto request)
        {
            return await _service.Update(id, request) ? Ok("Editado com sucesso") : BadRequest("Error ao editar");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await _service.Delete(id) ? Ok("Deletado com sucesso") : BadRequest("Error ao deletar");
        }
    }
}
