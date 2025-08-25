using TestOptimizePerformance.Models;

namespace TestOptimizePerformance.Dto
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public ReviewerDto Reviewer { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; } 
    }
}
