using FamilyIncomeApi.Models.Entities;

namespace FamilyIncomeApi.Repository.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> Get();
        Task<Category> GetById(int id);
        void Create(Category category);
        void Update(Category category);
        void Delete(Category category);
        Task<bool> SaveChangesAsync();
    }
}
