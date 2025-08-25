using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using TestOptimizePerformance;
using TestOptimizePerformance.Data;
using TestOptimizePerformance.Service;
using TestOptimizePerformance.Interface;
using StackExchange.Profiling;
using StackExchange.Profiling.Storage;
using Microsoft.Extensions.Caching.Memory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<Seed>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IProductServiceSlow,ProductServiceSlow>();

builder.Services.AddScoped<IProductServiceOptimized,ProductServiceOptimized>();

builder.Services.AddMemoryCache();

builder.Services.AddMiniProfiler(options =>
{
    options.RouteBasePath = "/profiler";
    options.Storage = new MemoryCacheStorage(builder.Services.BuildServiceProvider()
        .GetRequiredService<IMemoryCache>(),
        TimeSpan.FromMinutes(60));
}).AddEntityFramework();

var app = builder.Build();
if (args.Length == 1 && args[0].ToLower() == "seeddata")
{
    SeedData(app);
    return;
}
void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<Seed>();
        service.SeedDataContext();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiniProfiler();

app.UseAuthorization();

app.MapControllers();

app.Run();
