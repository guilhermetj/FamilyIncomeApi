using FamilyIncomeApi.Data;
using FamilyIncomeApi.Data.Dtos.ResumeDtos;
using FamilyIncomeApi.Models.Entities;
using FamilyIncomeApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FamilyIncomeApi.Repository
{
    public class ResumeRepository : IResumeRepository
    {
        private readonly FamilyIncomeContext _context;
        public ResumeRepository(FamilyIncomeContext context)
        {
            _context = context;
        }
        public async Task<ResumeDto> GetResume(int year, int month)
        {
            var revenue = await _context.revenues.Where(x => x.Date.Year == year && x.Date.Month == month).ToListAsync();
            var expenditure = await _context.expenditures.Include(c => c.Category).Where(x => x.Date.Year == year && x.Date.Month == month).ToListAsync(); 

            var revenueTotal = revenue.Sum(x => x.Value);
            var expenditureTotal = expenditure.Sum(x => x.Value);
            var categoryValue = expenditure.GroupBy(x => x.Category.Name).Select(x => new ValorCategoriaDto { CategoryName = x.Key, Value = Math.Round(x.Sum(s => s.Value)) });

            ResumeDto resume = new ResumeDto
            {
                TotalRevenue = Math.Round(revenueTotal, 2),
                TotalExpenditure = Math.Round(expenditureTotal, 2),
                FinalBalance = Math.Round(revenueTotal - expenditureTotal, 2),
                CategoryValue = categoryValue
            };
            return resume;
        }
    }
}
