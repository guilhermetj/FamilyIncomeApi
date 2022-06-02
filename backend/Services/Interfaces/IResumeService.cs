using FamilyIncomeApi.Data.Dtos.ResumeDtos;

namespace FamilyIncomeApi.Services.Interfaces
{
    public interface IResumeService
    {
        Task<ResumeDto> GetResume(int year, int month);
    }
}
