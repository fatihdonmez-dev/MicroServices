using Catalog.API.Dtos;
using Shared.Dtos;

namespace Catalog.API.Services
{
    public interface IProductService
    {
        Task<Response<List<ProductDto>>> GetAllAsync();
        Task<Response<ProductDto>> GetByIdAsnyc(string id);
        Task<Response<List<ProductDto>>> GetAllByUserId(string userId);
        Task<Response<ProductDto>> CreateAsync(ProductCreateDto productCreateDto);
        Task<Response<NoContent>> UpdateAsync(ProductUpdateDto productUpdateDto);
        Task<Response<NoContent>> DeleteAsync(string id);
    }
}
