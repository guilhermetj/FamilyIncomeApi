using FamilyIncomeApi.Data.Dtos.CategoryDtos;
using FamilyIncomeApi.Models.Entities;
using FamilyIncomeApi.Repository.Interfaces;

namespace FamilyIncomeApi.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDetailsDto>> Get();
        Task<CategoryDetailsDto> GetById(int id);
        Task<bool> Create(CategoryDto category);
        Task<bool> Update(int id, CategoryDto category);
        Task<bool> Delete(int id);
    }
}
