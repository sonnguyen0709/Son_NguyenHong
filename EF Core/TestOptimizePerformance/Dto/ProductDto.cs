
namespace TestOptimizePerformance.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ReviewDto>? Reviews { get; set; }
        public List<StoreDto>? Stores { get; set; }
    }
}
