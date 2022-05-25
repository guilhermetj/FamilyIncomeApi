namespace FamilyIncomeApi.Models.Dtos.RevenueDtos
{
    public class RevenueUpdateDto
    {
        public string? Description { get; set; }
        public string? Caregory { get; set; }
        public decimal? Value { get; set; }
        public DateTime? Date { get; set; }
    }
}
