using FamilyIncomeApi.Data.Dtos.ResumeDtos;

namespace FamilyIncomeApi.Repository.Interfaces
{
    public interface IResumeRepository
    {
        Task<ResumeDto> GetResume(int year, int month);
    }
}
