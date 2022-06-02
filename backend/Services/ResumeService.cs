using FamilyIncomeApi.Extensions;
using FamilyIncomeApi.Data.Dtos.ResumeDtos;
using FamilyIncomeApi.Repository.Interfaces;
using FamilyIncomeApi.Services.Interfaces;

namespace FamilyIncomeApi.Services
{
    public class ResumeService : IResumeService
    {
        private readonly IResumeRepository _repository;

        public ResumeService(IResumeRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResumeDto> GetResume(int year, int month)
        {
            return await _repository.GetResume(year, month);
        }
    }
}
