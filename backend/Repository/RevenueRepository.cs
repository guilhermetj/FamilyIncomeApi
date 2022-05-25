using FamilyIncomeApi.Data;
using FamilyIncomeApi.Models.Entities;
using FamilyIncomeApi.Models.Params;
using FamilyIncomeApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FamilyIncomeApi.Repository
{
    public class RevenueRepository : IRevenueRepository
    {
        private readonly FamilyIncomeContext _context;
        public RevenueRepository(FamilyIncomeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Revenue>> Get(RevenueParams revenueParams)
        {
            var revenue = _context.revenues.Select(x => new Revenue { 
                id = x.id,
                Description = x.Description,
                Caregory = x.Caregory,
                Date = x.Date,
                Value = x.Value
            }).AsQueryable();

            if (!string.IsNullOrEmpty(revenueParams.DescriptionRevenue))
            {
                string description = revenueParams.DescriptionRevenue.ToLower().Trim();
                revenue = revenue.Where(x => x.Description.ToLower().Contains(description));
            }

            return await revenue.ToListAsync();
        }
        public async Task<Revenue> GetById(int id)
        {
            return await _context.revenues.Where(x => x.id == id).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Revenue>> GetByMonth(int year, int month)
        {
            return await _context.revenues.Where(x => x.Date.Year == year && x.Date.Month == month).ToListAsync();
        }
        public async Task<Revenue> GetByDate(int month, string description)
        {
            return await _context.revenues.Where(x => x.Date.Month == month && x.Description == description).FirstOrDefaultAsync();
        }
        public void Create(Revenue revenue)
        {
            _context.Add(revenue);
        }
        public void Update(Revenue revenue)
        {
            _context.Update(revenue);
        }
        public void Delete(Revenue revenue)
        {
            _context.Remove(revenue);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }


    }
}
