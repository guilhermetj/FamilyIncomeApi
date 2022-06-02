using AutoMapper;
using FamilyIncomeApi.Extensions;
using FamilyIncomeApi.Data.Dtos.RevenueDtos;
using FamilyIncomeApi.Models.Entities;
using FamilyIncomeApi.Models.Params;
using FamilyIncomeApi.Repository.Interfaces;
using FamilyIncomeApi.Services.Interfaces;

namespace FamilyIncomeApi.Services
{
    public class RevenueService : IRevenueService
    {
        private readonly IRevenueRepository _repository;
        private readonly IMapper _mapper;
        public RevenueService(IRevenueRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<RevenueDto>> Get(RevenueParams revenueParams)
        {
            var revenue = await _repository.Get(revenueParams);

            return _mapper.Map<IEnumerable<RevenueDto>>(revenue);
        }
        public async Task<RevenueDetailsDto> GetById(int id)
        {
            var revenueBanco = await _repository.GetById(id);

            return _mapper.Map<RevenueDetailsDto>(revenueBanco);
        }
        public async Task<IEnumerable<RevenueDetailsDto>> GetByMonth(int year, int month)
        {
            var revenueBanco = await _repository.GetByMonth(year, month);

            return _mapper.Map<IEnumerable<RevenueDetailsDto>>(revenueBanco);
        }
        public async Task<RevenueDetailsDto> GetByDate(int month, string description)
        {
            var revenueBanco = await _repository.GetByDate(month, description);

            return _mapper.Map<RevenueDetailsDto>(revenueBanco);
        }
        public async Task<bool> Create(RevenueCreateDto revenue)
        {
            var revenueCreate = _mapper.Map<Revenue>(revenue);

            var revenueReturn = await _repository.GetByDate(revenue.Date.Month, revenue.Description);
            if(revenueReturn != null)
            {
                throw new NotFoundException("Você já registrou está receita");
            }
            _repository.Create(revenueCreate);

            return await _repository.SaveChangesAsync();
        }
        public async Task<bool> Update(int id, RevenueUpdateDto revenue)
        {
            var revenueBanco = await _repository.GetById(id);
            if (revenueBanco == null)
            {
                throw new NotFoundException("Receita não encontrada");
            }

            var revenueUpdate = _mapper.Map(revenue, revenueBanco);

            _repository.Update(revenueUpdate);

            return await _repository.SaveChangesAsync();
        }
        public async Task<bool> Delete(int id)
        {
            var revenueBanco = await _repository.GetById(id);
            if (revenueBanco == null)
            {
                throw new NotFoundException("Receita não encontrada");
            }

            _repository.Delete(revenueBanco);

            return await _repository.SaveChangesAsync();
        }
    }
}
