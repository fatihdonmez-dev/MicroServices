using Catalog.API.Dtos;
using Catalog.API.Models;
using Shared.Dtos;

namespace Catalog.API.Services
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryDto>> CreateAsync(CategoryCreateDto categoryCreateDto);
        Task<Response<CategoryDto>> GetByIdAsync(string id);
        Task<Response<NoContent>> UpdateAsync(CategoryUpdateDto categoryUpdateDto);
        Task<Response<NoContent>> DeleteAsync(string id);
    }
}
