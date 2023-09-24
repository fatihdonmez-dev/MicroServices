using Catalog.API.Dtos;
using Catalog.API.Models;
using Shared.Dtos;

namespace Catalog.API.Services
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryDto>> CreateAsync(Category category);
        Task<Response<CategoryDto>> GetByIdAsync(string id);
    }
}
