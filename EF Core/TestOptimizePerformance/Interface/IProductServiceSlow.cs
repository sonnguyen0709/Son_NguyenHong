using TestOptimizePerformance.Dto;

namespace TestOptimizePerformance.Interface
{
    public interface IProductServiceSlow
    {
        ICollection<ProductDto> GetAllProduct();
        ProductDto? GetProductById(int id);
        List<StoreDto>? GetStoreByProduct(int id);
    }
}
