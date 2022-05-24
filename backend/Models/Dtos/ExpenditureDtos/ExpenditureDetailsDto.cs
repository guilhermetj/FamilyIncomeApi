namespace FamilyIncomeApi.Models.Dtos.ExpenditureDtos
{
    public class ExpenditureDetailsDto
    {
        public int id { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
    }
}
