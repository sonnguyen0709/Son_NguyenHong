using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using TestOptimizePerformance.Data;
using TestOptimizePerformance.Models;
using TestOptimizePerformance.Interface;
using TestOptimizePerformance.Dto;

namespace TestOptimizePerformance.Service
{
    public class ProductServiceSlow : IProductServiceSlow
    {
        public readonly DataContext _context;
        public ProductServiceSlow(DataContext context)
        {
            _context = context;
        }
        public ICollection<ProductDto> GetAllProduct()
        {
            var products = _context.Products.ToList();
            return products.Select(p => new ProductDto
            {
                Id = p.ProductId,
                Name = p.Name,
                Reviews = _context.Reviews
                        .Where(r => r.ProductId == p.ProductId)
                        .Select(r => new ReviewDto
                        {
                            Id = r.ReviewId,
                            Comment = r.Comment,
                            Rating = r.Rating,
                            Reviewer = new ReviewerDto
                            {
                                Id = r.Reviewer.ReviewerId,
                                Name = r.Reviewer.Name
                            }
                        }).ToList(),
                Stores = _context.StoreProducts
                        .Where(sp => sp.ProductId == p.ProductId)
                        .Select(sp => new StoreDto
                        {
                            StoreId = sp.Store.StoreId,
                            Name = sp.Store.Name
                        }).ToList()
            }).ToList();
        }

        public ProductDto? GetProductById(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
            if (product == null) return null;

            return new ProductDto
            {
                Id = product.ProductId,
                Name = product.Name,
                Reviews = _context.Reviews
                            .Where(r => r.ProductId == product.ProductId)
                            .Select(r => new ReviewDto
                            {
                                Id = r.ReviewId,
                                Comment = r.Comment,
                                Rating = r.Rating,
                                Reviewer = new ReviewerDto
                                {
                                    Id = r.Reviewer.ReviewerId,
                                    Name = r.Reviewer.Name
                                }
                            }).ToList(),
                Stores = _context.StoreProducts
                            .Where(sp => sp.ProductId == product.ProductId)
                            .Select(sp => new StoreDto
                            {
                                StoreId = sp.Store.StoreId,
                                Name = sp.Store.Name
                            }).ToList()
            };
        }
        public List<StoreDto>? GetStoreByProduct(int id)
        {
            return _context.StoreProducts
                .Where(sp => sp.ProductId == id)
                .Select(sp => new StoreDto
                {
                    StoreId = sp.Store.StoreId,
                    Name = sp.Store.Name
                }).ToList();
        }
    }
}
