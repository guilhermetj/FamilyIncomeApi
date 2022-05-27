using FamilyIncomeApi.Data;
using FamilyIncomeApi.Models.Entities;
using FamilyIncomeApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FamilyIncomeApi.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly FamilyIncomeContext _context;
        public CategoryRepository(FamilyIncomeContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Category>> Get()
        {
            return await _context.categories.ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
            return await _context.categories.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public void Create(Category category)
        {
            _context.Add(category);
        }
        public void Update(Category category)
        {
            _context.Update(category);
        }
        public void Delete(Category category)
        {
            _context.Remove(category);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
