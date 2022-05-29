using AutoMapper;
using FamilyIncomeApi.Extensions;
using FamilyIncomeApi.Models.Dtos.ExpenditureDtos;
using FamilyIncomeApi.Models.Entities;
using FamilyIncomeApi.Models.Params;
using FamilyIncomeApi.Repository.Interfaces;
using FamilyIncomeApi.Services.Interfaces;

namespace FamilyIncomeApi.Services
{
    public class ExpenditureService : IExpenditureService
    {
        private readonly IExpenditureRepository _repository;
        private readonly IMapper _mapper;
        public ExpenditureService(IExpenditureRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ExpenditureDto>> Get(ExpenditureParams expenditureParams)
        {
            var expenditure = await _repository.Get(expenditureParams);

            return _mapper.Map<IEnumerable<ExpenditureDto>>(expenditure);
        }
        public async Task<ExpenditureDetailsDto> GetById(int id)
        {
            var expenditureBanco = await _repository.GetById(id);

           return _mapper.Map<ExpenditureDetailsDto>(expenditureBanco);
        }
        public async Task<ExpenditureDetailsDto> GetByDate(int month, string description)
        {
            var expenditureBanco = await _repository.GetByDate(month, description);

            return _mapper.Map<ExpenditureDetailsDto>(expenditureBanco);
        }
        public async Task<IEnumerable<ExpenditureDetailsDto>> GetByMonth(int year, int month)
        {
            var expenditureBanco = await _repository.GetByMonth(year, month);

            return _mapper.Map<IEnumerable<ExpenditureDetailsDto>>(expenditureBanco);
        }
        public async Task<bool> Create(ExpenditureCreateDto expenditure)
        {
            var expenditureBanco = await _repository.GetByDate(expenditure.Date.Month, expenditure.Description);
            if(expenditureBanco != null)
            {
                throw new NotFoundException("Você já registrou está despesa");
            }
            var expenditureCreate = _mapper.Map<Expenditure>(expenditure);

            _repository.Create(expenditureCreate);

            return await _repository.SaveChangesAsync();
        }
        public async Task<bool> Update(int id, ExpenditureUpdateDto expenditure)
        {
            var expenditureBanco = await _repository.GetById(id);
            if (expenditureBanco == null)
            {
                throw new NotFoundException("Despesa não encontrada");
            }
            var expenditureUpdate = _mapper.Map(expenditure, expenditureBanco);

            _repository.Update(expenditureUpdate);

            return await _repository.SaveChangesAsync();
        }
        public async Task<bool> Delete(int id)
        {
            var expenditureBanco = await _repository.GetById(id);
            if (expenditureBanco == null)
            {
                throw new NotFoundException("Despesa não encontrada");
            }
           
            _repository.Delete(expenditureBanco);

            return await _repository.SaveChangesAsync();
        }
    }
}
