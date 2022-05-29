using FamilyIncomeApi.Controllers;
using FamilyIncomeApi.Models.Dtos.CategoryDtos;
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
        public CategoryControllerFactory CriaCategorias(CategoryDto categoria)
        {
            _categoryService.Setup(x => x.Create(categoria)).ReturnsAsync(true);
            return this;
        }
        
        public ICategoryService Service()
        {
            return _categoryService.Object;
        }
        public CategoryController Controller()
        {
            return new CategoryController(_categoryService.Object);
        }
    }
}
