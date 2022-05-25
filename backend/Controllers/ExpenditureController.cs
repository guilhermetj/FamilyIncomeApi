using AutoMapper;
using FamilyIncomeApi.Models.Dtos.ExpenditureDtos;
using FamilyIncomeApi.Models.Entities;
using FamilyIncomeApi.Models.Params;
using FamilyIncomeApi.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FamilyIncomeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExpenditureController : ControllerBase
    {
        private readonly IExpenditureRepository _repository;
        private readonly IMapper _mapper;
        public ExpenditureController(IExpenditureRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]ExpenditureParams expenditureParams)
        {
            var expenditure = await _repository.Get(expenditureParams);

            var expenditureReturn = _mapper.Map<IEnumerable<ExpenditureDto>>(expenditure);

            return Ok(expenditureReturn);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var expenditureBanco = await _repository.GetById(id);
            if (expenditureBanco == null) return BadRequest("Error ao encontrar despesas");

            var expenditureReturn = _mapper.Map<ExpenditureDetailsDto>(expenditureBanco);

            return Ok(expenditureReturn);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ExpenditureCreateDto request)
        {
            var expenditure = _mapper.Map<Expenditure>(request);

            var expenditureReturn = await _repository.GetByDate(request.Date.Month, request.Description);
            if (expenditureReturn != null) return BadRequest("Esta despesa já existe");

            _repository.Create(expenditure);

            return await _repository.SaveChangesAsync() ? Ok("Criado com sucesso") : BadRequest("Error ao criar");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, ExpenditureUpdateDto request)
        {
            var expenditureBanco = await _repository.GetById(id);
            if (expenditureBanco == null) return BadRequest("Error ao encontrar despesas");

            var expenditure = _mapper.Map(request, expenditureBanco);

            _repository.Update(expenditure);

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
