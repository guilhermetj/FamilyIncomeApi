using FamilyIncomeApi.Models.Dtos.CategoryDtos;
using FamilyIncomeApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FamilyIncomeApi.Models.Dtos.ResumeDtos
{
    public class ResumeDto
    {
        public double TotalRevenue { get; set; }
        public double TotalExpenditure { get; set; }
        public double FinalBalance { get; set; }
        public IEnumerable<ValorCategoriaDto>? CategoryValue { get; set; }
    }
    public class ValorCategoriaDto
    {
        public string CategoryName { get; set; }
        public double Value { get; set; }
    }
}
