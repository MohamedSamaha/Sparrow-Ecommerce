using SparrowManagementSystem.Core.DTOs;

namespace SparrowManagementSystem.Core.Interfaces.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProducts();
        Task<ProductDto> GetProductById(int id);
        Task<ProductDto> CreateProduct(ProductDto productDto);
        Task<ProductDto> UpdateProduct(ProductDto productDto);
        Task DeleteProduct(int id);
    }
}
