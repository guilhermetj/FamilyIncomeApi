using AutoMapper;
using FamilyIncomeApi.Extensions;
using FamilyIncomeApi.Data.Dtos.CategoryDtos;
using FamilyIncomeApi.Models.Entities;
using FamilyIncomeApi.Repository.Interfaces;
using FamilyIncomeApi.Services.Interfaces;

namespace FamilyIncomeApi.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CategoryDetailsDto>> Get()
        {
            var category = await _repository.Get();

            return _mapper.Map<IEnumerable<CategoryDetailsDto>>(category);

        }
        public async Task<CategoryDetailsDto> GetById(int id)
        {
            var category = await _repository.GetById(id);

            return _mapper.Map<CategoryDetailsDto>(category);

        }
        public async Task<bool> Create(CategoryDto category)
        {
            var categoriaAdicionar = _mapper.Map<Category>(category);

            _repository.Create(categoriaAdicionar);

            return await _repository.SaveChangesAsync();
        }
        public async Task<bool> Update(int id, CategoryDto category)
        {
            var categoryDatabase = await _repository.GetById(id);

            if(categoryDatabase == null)
            {
                throw new NotFoundException("Categoria não encontrada");
            }

            var categoryUpdate = _mapper.Map(category, categoryDatabase);
            _repository.Update(categoryUpdate);
            return await _repository.SaveChangesAsync();
        
        }
        public async Task<bool> Delete(int id)
        {
            var categoryDatabase = await _repository.GetById(id);

            if (categoryDatabase == null)
            {
                throw new NotFoundException("Categoria não encontrada");
            }

            _repository.Delete(categoryDatabase);
            
            return await _repository.SaveChangesAsync();

        }
    }
}
