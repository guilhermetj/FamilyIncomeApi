using FamilyIncomeApi.Models.Entities;

namespace FamilyIncomeApi.Models.Dtos.ExpenditureDtos
{
    public class ExpenditureDetailsDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }
    }
}
