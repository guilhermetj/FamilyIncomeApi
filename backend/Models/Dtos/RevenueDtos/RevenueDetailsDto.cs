namespace FamilyIncomeApi.Models.Dtos.RevenueDtos
{
    public class RevenueDetailsDto
    {
        public int id { get; set; }
        public string Description { get; set; }
        public string Caregory { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
    }
}
