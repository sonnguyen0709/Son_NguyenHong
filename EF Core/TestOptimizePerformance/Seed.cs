using TestOptimizePerformance.Models;
using TestOptimizePerformance.Data;

namespace TestOptimizePerformance
{
    public class Seed
    {
        private readonly DataContext _context;
        public Seed(DataContext context)
        {
            _context = context;
        }
        public void SeedDataContext()
        {
            if (!_context.Stores.Any() && !_context.Products.Any())
            {
                var stores = Enumerable.Range(1, 10)
                    .Select(i => new Store { Name = $"Store {i}" })
                    .ToList();

                var reviewers = Enumerable.Range(1, 10)
                    .Select(i => new Reviewer { Name = $"Reviewer {i}" })
                    .ToList();

                var products = Enumerable.Range(1, 100)
                    .Select(i => new Product { Name = $"Product {i}" })
                    .ToList();

                _context.Stores.AddRange(stores);
                _context.Reviewers.AddRange(reviewers);
                _context.Products.AddRange(products);
                _context.SaveChanges();

                var rand = new Random();
                var storeProducts = new List<StoreProduct>();
                foreach (var product in products)
                {
                    var storeIds = stores.OrderBy(s => rand.Next()).Take(2).Select(s => s.StoreId).ToList();
                    foreach (var storeId in storeIds)
                    {
                        storeProducts.Add(new StoreProduct
                        {
                            StoreId = storeId,
                            ProductId = product.ProductId
                        });
                    }
                }

                _context.StoreProducts.AddRange(storeProducts);

                var reviews = new List<Review>();
                int reviewerIndex = 0;
                foreach (var product in products)
                {
                    for (int i = 1; i <= 2; i++)
                    {
                        var reviewer = reviewers[reviewerIndex % reviewers.Count];
                        reviews.Add(new Review
                        {
                            ProductId = product.ProductId,
                            ReviewerId = reviewer.ReviewerId,
                            Comment = $"Review {i} for Product {product.ProductId}",
                            Rating = rand.Next(1, 6)
                        });
                        reviewerIndex++;
                    }
                }
                _context.Reviews.AddRange(reviews);
                _context.SaveChanges();
            }
        }
    }
}
