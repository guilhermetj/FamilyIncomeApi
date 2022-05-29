using FamilyIncomeApi.Models.Dtos.RevenueDtos;
using FamilyIncomeApi.Models.Entities;
using FamilyIncomeApi.Models.Params;

namespace FamilyIncomeApi.Services.Interfaces
{
    public interface IRevenueService
    {
        Task<IEnumerable<RevenueDto>> Get(RevenueParams revenueParams);
        Task<IEnumerable<RevenueDetailsDto>> GetByMonth(int year, int month);
        Task<RevenueDetailsDto> GetById(int id);
        Task<RevenueDetailsDto> GetByDate(int month, string description);
        Task<bool> Create(RevenueCreateDto revenue);
        Task<bool> Update(int id, RevenueUpdateDto revenue);
        Task<bool> Delete(int id);
    }
}
