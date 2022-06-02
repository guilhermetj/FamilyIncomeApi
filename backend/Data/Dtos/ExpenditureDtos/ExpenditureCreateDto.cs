using FamilyIncomeApi.Models.Entities;

namespace FamilyIncomeApi.Data.Dtos.ExpenditureDtos
{
    public class ExpenditureCreateDto
    {
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }
    }
}
