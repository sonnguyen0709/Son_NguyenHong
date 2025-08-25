namespace TestOptimizePerformance.Models
{
    public class Reviewer
    {
        public int ReviewerId { get; set; }
        public string Name { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
