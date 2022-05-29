using FamilyIncomeApi.Models.Dtos.ExpenditureDtos;
using FamilyIncomeApi.Models.Params;

namespace FamilyIncomeApi.Services.Interfaces
{
    public interface IExpenditureService
    {
        Task<IEnumerable<ExpenditureDto>> Get(ExpenditureParams expenditureParams);
        Task<IEnumerable<ExpenditureDetailsDto>> GetByMonth(int year, int month);
        Task<ExpenditureDetailsDto> GetById(int id);
        Task<ExpenditureDetailsDto> GetByDate(int month, string description);
        Task<bool> Create(ExpenditureCreateDto expenditure);
        Task<bool> Update(int id, ExpenditureUpdateDto expenditure);
        Task<bool> Delete(int id);

    }
}
