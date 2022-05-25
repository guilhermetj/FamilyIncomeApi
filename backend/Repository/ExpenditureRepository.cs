using FamilyIncomeApi.Data;
using FamilyIncomeApi.Models.Entities;
using FamilyIncomeApi.Models.Params;
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

        public async Task<IEnumerable<Expenditure>> Get(ExpenditureParams expenditureParams)
        {
            var expenditure = _context.expenditures.Select(x => new Expenditure
            {
                id = x.id,
                Description = x.Description,
                Caregory = x.Caregory,
                Date = x.Date,
                Value = x.Value
            }).AsQueryable();

            if (!string.IsNullOrEmpty(expenditureParams.DescriptionExpenditure))
            {
                string description = expenditureParams.DescriptionExpenditure.ToLower().Trim();
                expenditure = expenditure.Where(x => x.Description.ToLower().Contains(description));
            }

            return await expenditure.ToListAsync();
        }
        public async Task<Expenditure> GetById(int id)
        {
            return await _context.expenditures.Where(x => x.id == id).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Expenditure>> GetByMonth(int year, int month)
        {
            return await _context.expenditures.Where(x => x.Date.Year == year && x.Date.Month == month).ToListAsync();
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
