using FamilyIncomeApi.Models.Entities;
using FamilyIncomeApi.Models.Params;

namespace FamilyIncomeApi.Repository.Interfaces
{
    public interface IRevenueRepository
    {
        Task<IEnumerable<Revenue>> Get(RevenueParams revenueParams);
        Task<Revenue> GetById(int id);
        Task<Revenue> GetByDate(int month, string description);
        void Create(Revenue revenue);
        void Update(Revenue revenue);
        void Delete(Revenue revenue);
        Task<bool> SaveChangesAsync();
    }
}
