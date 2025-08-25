using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using TestOptimizePerformance.Data;
using TestOptimizePerformance.Models;
using TestOptimizePerformance.Interface;
using TestOptimizePerformance.Dto;

namespace TestOptimizePerformance.Service
{
    public class ProductServiceOptimized : IProductServiceOptimized
    {
        public readonly DataContext _context;
        public ProductServiceOptimized(DataContext context)
        {
            _context = context;
        }
        public ICollection<ProductDto> GetAllProduct(int page, int pageSize)
        {
            return _context.Products
            .AsNoTracking()
            .AsSplitQuery()
            .Include(p => p.Reviews).ThenInclude(r => r.Reviewer)
            .Include(p => p.StoreProducts).ThenInclude(sp => sp.Store)
            .OrderBy(p => p.ProductId) 
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(p => new ProductDto
            {
                Id = p.ProductId,
                Name = p.Name,
                Reviews = p.Reviews.Select(r => new ReviewDto
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
                Stores = p.StoreProducts.Select(sp => new StoreDto
                {
                    StoreId = sp.Store.StoreId,
                    Name = sp.Store.Name
                }).ToList()
            }).ToList();
        }
        public ProductDto? GetProductById(int id)
        {
            return _context.Products
            .AsNoTracking()
            .AsSplitQuery()
            .Where(p => p.ProductId == id)
            .Include(p => p.Reviews).ThenInclude(r => r.Reviewer)
            .Include(p => p.StoreProducts).ThenInclude(sp => sp.Store)
            .Select(p => new ProductDto
            {
                Id = p.ProductId,
                Name = p.Name,
                Reviews = p.Reviews.Select(r => new ReviewDto
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
                Stores = p.StoreProducts.Select(sp => new StoreDto
                {
                    StoreId = sp.Store.StoreId,
                    Name = sp.Store.Name
                }).ToList()
            }).SingleOrDefault();
        }
        public List<StoreDto>? GetStoreByProduct(int id)
        {
            return _context.StoreProducts
            .AsNoTracking()
            .Where(sp => sp.ProductId == id)
            .Select(sp => new StoreDto
            {
                StoreId = sp.Store.StoreId,
                Name = sp.Store.Name
            }).ToList();
        }
    }
}
