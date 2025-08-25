namespace TestOptimizePerformance.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public ICollection<StoreProduct> StoreProducts { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
