using FamilyIncomeApi.Models.Dtos.ExpenditureDtos;
using FamilyIncomeApi.Models.Dtos.ResumeDtos;

namespace FamilyIncomeApi.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Expenditure> Expenditure { get; set; }
    }
}
