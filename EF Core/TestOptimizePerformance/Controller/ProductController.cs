using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestOptimizePerformance.Interface;
using TestOptimizePerformance.Service;

namespace TestOptimizePerformance.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductServiceSlow _normalService;
        private readonly IProductServiceOptimized _optimizedService;
        public ProductController(IProductServiceSlow normalService,
            IProductServiceOptimized optimizedService)
        {
            _normalService = normalService;
            _optimizedService = optimizedService;
        }

        [HttpGet("compare/get-all")]
        public IActionResult CompareGetAll([FromQuery]int page = 1, [FromQuery]int pageSize = 10)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            var normalResult = _normalService.GetAllProduct();
            stopwatch.Stop();
            var normalTime = stopwatch.ElapsedMilliseconds;

            stopwatch.Restart();
            var optimizedResult = _optimizedService.GetAllProduct(page, pageSize);
            stopwatch.Stop();
            var optimizedTime = stopwatch.ElapsedMilliseconds;

            return Ok(new
            {
                Method = "GetAllProduct",
                Page = page,
                PageSize = pageSize,
                NormalServiceTimeMs = normalTime,
                OptimizedServiceTimeMs = optimizedTime,
                NormalCount = normalResult.Count(),
                OptimizedCount = optimizedResult.Count()
            });
        }

        [HttpGet("compare/get-by-id/{id}")]
        public IActionResult CompareGetById(int id)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            var normalResult = _normalService.GetProductById(id);
            stopwatch.Stop();
            var normalTime = stopwatch.ElapsedMilliseconds;

            stopwatch.Restart();
            var optimizedResult = _optimizedService.GetProductById(id);
            stopwatch.Stop();
            var optimizedTime = stopwatch.ElapsedMilliseconds;

            return Ok(new
            {
                Method = "GetProductById",
                NormalServiceTimeMs = normalTime,
                OptimizedServiceTimeMs = optimizedTime,
                NormalResult = normalResult,
                OptimizedResult = optimizedResult
            });
        }

        [HttpGet("compare/get-stores/{id}")]
        public IActionResult CompareGetStores(int id)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            var normalResult = _normalService.GetStoreByProduct(id);
            stopwatch.Stop();
            var normalTime = stopwatch.ElapsedMilliseconds;

            stopwatch.Restart();
            var optimizedResult = _optimizedService.GetStoreByProduct(id);
            stopwatch.Stop();
            var optimizedTime = stopwatch.ElapsedMilliseconds;

            return Ok(new
            {
                Method = "GetStoreByProduct",
                NormalServiceTimeMs = normalTime,
                OptimizedServiceTimeMs = optimizedTime,
                NormalCount = normalResult?.Count ?? 0,
                OptimizedCount = optimizedResult?.Count ?? 0
            });
        }
    }
}
