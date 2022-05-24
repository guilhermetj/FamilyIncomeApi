using FamilyIncomeApi.Models.Entities;

namespace FamilyIncomeApi.Repository.Interfaces
{
    public interface IExpenditureRepository
    {
        Task<IEnumerable<Expenditure>> Get();
        Task<Expenditure> GetById(int id);
        void Create(Expenditure expenditure);
        void Update(Expenditure expenditure);
        void Delete(Expenditure expenditure);
        Task<bool> SaveChangesAsync();
    }
}
