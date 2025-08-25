using TestOptimizePerformance.Dto;
using TestOptimizePerformance.Models;

namespace TestOptimizePerformance.Interface
{
    public interface IProductServiceOptimized
    {
        ICollection<ProductDto> GetAllProduct(int page, int pageSize);
        ProductDto? GetProductById(int id);
        List<StoreDto>? GetStoreByProduct(int id);
    }
}
