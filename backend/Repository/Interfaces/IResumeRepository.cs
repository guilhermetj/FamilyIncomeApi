using FamilyIncomeApi.Models.Dtos.ResumeDtos;

namespace FamilyIncomeApi.Repository.Interfaces
{
    public interface IResumeRepository
    {

        Task<ResumeDto> GetResume(int year, int month);
    }
}
