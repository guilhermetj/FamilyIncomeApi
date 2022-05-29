namespace FamilyIncomeApi.Models.Dtos.ExpenditureDtos
{
    public class ExpenditureUpdateDto
    {
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }
    }
}
