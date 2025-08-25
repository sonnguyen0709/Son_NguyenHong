namespace TestOptimizePerformance.Models
{
    public class Store
    {
        public int StoreId { get; set; }
        public string Name { get; set; }
        public ICollection<StoreProduct> StoreProducts { get; set; }
    }
}
