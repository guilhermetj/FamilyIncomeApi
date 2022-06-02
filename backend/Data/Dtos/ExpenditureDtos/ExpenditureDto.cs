using FamilyIncomeApi.Data.Dtos.CategoryDtos;
using FamilyIncomeApi.Models.Entities;

namespace FamilyIncomeApi.Data.Dtos.ExpenditureDtos
{
    public class ExpenditureDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }
    }
}
