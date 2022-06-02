using FamilyIncomeApi.Controllers;
using FamilyIncomeApi.Data.Dtos.CategoryDtos;
using FamilyIncomeApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyIncomeTestes.Factories.Controllers
{
    public class CategoryControllerFactory
    {
        private readonly Mock<ICategoryService> _categoryService;
        public CategoryControllerFactory()
        {
            _categoryService = new Mock<ICategoryService>();
        }
        public CategoryControllerFactory BuscaCategorias(IEnumerable<CategoryDetailsDto> categorias)
        {

            _categoryService.Setup(x => x.Get()).ReturnsAsync(categorias);

            return this;
        }
        public CategoryControllerFactory BuscaCategoriasPeloId(CategoryDetailsDto categorias)
        {
            _categoryService.Setup(x => x.GetById(1)).ReturnsAsync(categorias);

            return this;
        }
        public CategoryControllerFactory CriaCategorias(CategoryDto categoria)
        {
            _categoryService.Setup(x => x.Create(categoria)).ReturnsAsync(true);
            return this;
        }
        public CategoryControllerFactory AlteraCategorias(CategoryDto categoria)
        {
            _categoryService.Setup(x => x.Update(1, categoria)).ReturnsAsync(true);
            return this;
        }
        public CategoryControllerFactory DeletaCategorias(CategoryDto categoria)
        {
            _categoryService.Setup(x => x.Delete(1)).ReturnsAsync(true);
            return this;
        }
        public CategoryController Controller()
        {
            return new CategoryController(_categoryService.Object);
        }
    }
}
