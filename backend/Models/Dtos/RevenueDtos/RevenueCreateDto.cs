namespace FamilyIncomeApi.Models.Dtos.RevenueDtos
{
    public class RevenueCreateDto
    {
        public string Description { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }
    }
}
