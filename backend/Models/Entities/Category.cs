using FamilyIncomeApi.Data.Dtos.ExpenditureDtos;
using FamilyIncomeApi.Data.Dtos.ResumeDtos;

namespace FamilyIncomeApi.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Expenditure> Expenditure { get; set; }
    }
}
