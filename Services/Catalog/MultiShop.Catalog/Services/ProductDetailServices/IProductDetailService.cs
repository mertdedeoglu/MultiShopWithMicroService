using MultiShop.Catalog.Dtos.ProductDetailDtos;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
        Task CreateProductDetailAsync(CreateProductDetailDto createProduct);
        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProduct);
        Task DeleteProductDetailAsync(string id);
        Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id);
    }
}
