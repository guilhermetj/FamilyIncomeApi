using FamilyIncomeApi.Data;
using FamilyIncomeApi.Models.Entities;
using FamilyIncomeApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FamilyIncomeApi.Repository
{
    public class ExpenditureRepository : IExpenditureRepository
    {
        private readonly FamilyIncomeContext _context;
        public ExpenditureRepository(FamilyIncomeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Expenditure>> Get()
        {
            return await _context.expenditures.ToListAsync();
        }
        public async Task<Expenditure> GetById(int id)
        {
            return await _context.expenditures.Where(x => x.id == id).FirstOrDefaultAsync();
        }
        public async Task<Expenditure> GetByDate(int month, string description)
        {
            return await _context.expenditures.Where(x => x.Date.Month == month && x.Description == description).FirstOrDefaultAsync();
        }
        public void Create(Expenditure expenditure)
        {
            _context.Add(expenditure);
        }
        public void Update(Expenditure expenditure)
        {
            _context.Update(expenditure);
        }
        public void Delete(Expenditure expenditure)
        {
            _context.Remove(expenditure);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }


    }
}
