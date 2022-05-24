using AutoMapper;
using FamilyIncomeApi.Models.Dtos.RevenueDtos;
using FamilyIncomeApi.Models.Entities;
using FamilyIncomeApi.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FamilyIncomeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RevenueController : ControllerBase
    {
        private readonly IRevenueRepository _repository;
        private readonly IMapper _mapper;
        public RevenueController(IRevenueRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var revenue = await _repository.Get();

            var revenueReturn = _mapper.Map<IEnumerable<RevenueDto>>(revenue);

            return Ok(revenueReturn);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var revenueBanco = await _repository.GetById(id);
            if (revenueBanco == null) return BadRequest("Error ao encontrar receita");

            var revenueBancoReturn = _mapper.Map<RevenueDetailsDto>(revenueBanco);

            return Ok(revenueBancoReturn);
        }
        [HttpPost]
        public async Task<IActionResult> Add(RevenueCreateDto request)
        {
            var revenue = _mapper.Map<Revenue>(request);

            var revenueReturn = await _repository.GetByDate(request.Date.Month, request.Description);
            if (revenueReturn != null) return BadRequest("Esta Receita já existe");

            _repository.Create(revenue);

            return await _repository.SaveChangesAsync() ? Ok("Criado com sucesso") : BadRequest("Error ao criar");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, RevenueUpdateDto request)
        {
            var revenueBanco = await _repository.GetById(id);
            if (revenueBanco == null) return BadRequest("Error ao encontrar receita");

            var revenue = _mapper.Map(request, revenueBanco);

            _repository.Update(revenue);

            return await _repository.SaveChangesAsync() ? Ok("Editado com sucesso") : BadRequest("Error ao Editar");
        }
        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var revenueBanco = await _repository.GetById(id);
            if (revenueBanco == null) return BadRequest("Error ao encontrar receita");

            _repository.Delete(revenueBanco);

            return await _repository.SaveChangesAsync() ? Ok("Deletado com sucesso") : BadRequest("Error ao Deletar");
        }
    }
}
