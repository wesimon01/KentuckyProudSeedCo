using AspNetCoreRateLimit;
using KentuckyProudSeedCo.Data;
using KentuckyProudSeedCo.Data.DbContexts;
using KentuckyProudSeedCo.Data.Repos;
using KentuckyProudSeedCo.Service.StartupConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;


var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson()
  .AddXmlDataContractSerializerFormatters();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddResponseCaching();
services.AddMemoryCache();
services.AddHealthChecks();
builder.AddRateLimitServices();

services.AddSwaggerGen(options =>
{
    var securityScheme = new OpenApiSecurityScheme()
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT" // Optional
    };

    var securityRequirement = new OpenApiSecurityRequirement {
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "bearerAuth"
            }
        },
        new string[] {}
    }
};

    options.AddSecurityDefinition("bearerAuth", securityScheme);
    options.AddSecurityRequirement(securityRequirement);
});


services.AddDbContext<KentuckyProudSeedCoContext>(dbContextOptions => { 
    
    });

services.AddScoped<IGenericRepository, GenericRepository>();
services.AddScoped<IProductRepository, ProductRepository>();
//builder.Services.AddScoped<IGenericRepository, ProductCategoryRepository>();

services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

services.AddAuthentication("Bearer").AddJwtBearer(options => 
{ 
   options.TokenValidationParameters = new() { 
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateIssuerSigningKey = true,
    ValidIssuer = builder.Configuration["Authentication:Issuer"],
    ValidAudience = builder.Configuration["Authentication:Audience"],
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"]))
   };     
});

services.AddAuthorization(options =>
{
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(config =>
    {
        config.ConfigObject.AdditionalItems["syntaxHighlight"] = new Dictionary<string, object>
        {
            ["activated"] = false
        };
    });
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseResponseCaching();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
app.MapHealthChecks("/health").AllowAnonymous();
app.UseIpRateLimiting();
app.Run();