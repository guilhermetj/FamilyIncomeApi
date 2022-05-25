using FamilyIncomeApi.Models.Entities;
using FamilyIncomeApi.Models.Params;

namespace FamilyIncomeApi.Repository.Interfaces
{
    public interface IExpenditureRepository
    {
        Task<IEnumerable<Expenditure>> Get(ExpenditureParams expenditureParams);
        Task<Expenditure> GetById(int id);
        Task<Expenditure> GetByDate(int month, string description);
        void Create(Expenditure expenditure);
        void Update(Expenditure expenditure);
        void Delete(Expenditure expenditure);
        Task<bool> SaveChangesAsync();
    }
}
