namespace FamilyIncomeApi.Models.Dtos.RevenueDtos
{
    public class RevenueCreateDto
    {
        public string Description { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
    }
}
