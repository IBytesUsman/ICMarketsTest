using ICMarkets.DeveloperTest.API.Infrastructure.Startup;
using ICMarkets.DeveloperTest.Datacontext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication
    .CreateBuilder(args)
    .RegisterServices();
var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
builder.Configuration.AddJsonFile($"appsettings.{env}.json", false, true);
builder.Services.AddDbContext<ICMarketsDbContext>(options => options
    .UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")!, b=>b.MigrationsAssembly("ICMarkets.DeveloperTest.API"))
    .UseSnakeCaseNamingConvention(), ServiceLifetime.Singleton);
var app = builder
    .Build()
    .ConfigureMiddleware();
app.Run();