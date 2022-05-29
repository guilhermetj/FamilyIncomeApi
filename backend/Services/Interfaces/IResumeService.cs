using FamilyIncomeApi.Models.Dtos.ResumeDtos;

namespace FamilyIncomeApi.Services.Interfaces
{
    public interface IResumeService
    {
        Task<ResumeDto> GetResume(int year, int month);
    }
}
