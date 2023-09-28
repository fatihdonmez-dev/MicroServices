using Catalog.API.Dtos;
using Catalog.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.ControllerBases;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _categoryService.GetAllAsync();
            return CreateActionResultInstance(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var response = await _categoryService.GetByIdAsync(id);
            return CreateActionResultInstance(response);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDto categoryCreateDto)
        {
            var response = await _categoryService.CreateAsync(categoryCreateDto);

            return CreateActionResultInstance(response);

        }

        [HttpPut]
        public async Task<IActionResult> Update(CategoryUpdateDto categoryUpdateDto)
        {
            var response = await _categoryService.UpdateAsync(categoryUpdateDto);

            return CreateActionResultInstance(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _categoryService.DeleteAsync(id);

            return CreateActionResultInstance(response);
        }
    }
}
    