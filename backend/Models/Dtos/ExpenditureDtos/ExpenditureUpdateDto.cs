namespace FamilyIncomeApi.Models.Dtos.ExpenditureDtos
{
    public class ExpenditureUpdateDto
    {
        public string? Description { get; set; }
        public decimal? Value { get; set; }
        public DateTime? Date { get; set; }
    }
}
