using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;
using YugiohCard.Data;
using YugiohCard.Models;
using YugiohCard.Service;
using YugiohCard.Interface;

// Initialize builder object to configure service and middleware
var builder = WebApplication.CreateBuilder(args);

// Use Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// When you need IUserService, allocate UserService
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMonsterCardService, MonsterCardService>();

// Configure enum to return JSON as string
builder.Services.AddControllers()
    .AddJsonOptions(opts =>
    {
        opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

// Register authentication service into ASP.NET Core pipeline
builder.Services.AddAuthentication(options =>
{
    // Use JWT to check if the user is logged in or not, every time a request comes in
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

    // When the client is not logged in or the token is invalid, send back a 401 Unauthorized response
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
// Enable Bearer token authentication
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        // Check if the token has the correct Issuer
        ValidateIssuer = true,
        // Check if the token has the correct Audience
        ValidateAudience = true,
        // Check if token has expired
        ValidateLifetime = true,
        // Check if the token has the correct "key"
        ValidateIssuerSigningKey = true,
        // Get the "Jwt:Issuer" value from appsettings.json
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        // Similiar as Issuer
        ValidAudience = builder.Configuration["Jwt:Audience"],
        // Use secret key to check token
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

// Swagger display information about endpoints in API
builder.Services.AddEndpointsApiExplorer();

// Enable the in-app permission system (Can use [Authorize])
builder.Services.AddAuthorization();

// Register Swagger and configure API documentation interface
builder.Services.AddSwaggerGen(c =>
{
    // Create a title and version for the Swagger 
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "YugiohCardReview", Version = "v1" });

    // 
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        // Name of the header used to send the token
        Name = "Authorization",
        // Send token via API key header
        Type = SecuritySchemeType.ApiKey,
        // Identify the token as Bearer token
        Scheme = "Bearer",
        //Token format is JWT
        BearerFormat = "JWT",
        // Send token in Header
        In = ParameterLocation.Header,
        // User guide note for entering tokens
        Description = "JWT Token: "

        // When running Swagger, an "Authorize" button will appear for you to enter the token.
    });

    // Require all APIs to use JWT Bearer for protection if you attach [Authorize] on controller/method
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();

// Use Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Automatically redirect HTTP to HTTPS
app.UseHttpsRedirection();

// Checking JWT Token in requests
app.UseAuthentication();

// Check access (base on [Authorize] attibute)
app.UseAuthorization();

// Map [ApiController] controllers to routes
app.MapControllers();

// Run web application
app.Run();
