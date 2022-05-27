using AutoMapper;
using FamilyIncomeApi.Models.Dtos.CategoryDtos;
using FamilyIncomeApi.Models.Entities;
using FamilyIncomeApi.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FamilyIncomeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        ICategoryRepository _repository;
        IMapper _mapper;
        public CategoryController(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var category = await _repository.Get();

            return Ok(category);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var category = await _repository.GetById(id);
            if (category == null) return BadRequest("Categoria não encontrada");

            return Ok(category);         
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto request)
        {
            var category = _mapper.Map<Category>(request);

            _repository.Create(category);

            return await _repository.SaveChangesAsync() ? Ok("Criado com sucesso") : BadRequest("Error ao criar") ;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CategoryDto request)
        {
            var categoryDatabase = await _repository.GetById(id);
            if (categoryDatabase == null) return BadRequest("Categoria não encontrada");

            var expenditure = _mapper.Map(request, categoryDatabase);

            _repository.Update(categoryDatabase);

            return await _repository.SaveChangesAsync() ? Ok("Editado com sucesso") : BadRequest("Error ao editar");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var categoryDatabase = await _repository.GetById(id);
            if (categoryDatabase == null) return BadRequest("Categoria não encontrada");

            _repository.Delete(categoryDatabase);

            return await _repository.SaveChangesAsync() ? Ok("Deletado com sucesso") : BadRequest("Error ao deletar");
        }
    }
}
