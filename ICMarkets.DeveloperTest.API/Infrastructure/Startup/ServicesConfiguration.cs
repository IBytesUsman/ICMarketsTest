using AutoMapper;
using FluentValidation.AspNetCore;
using ICMarkets.Developer.Clients.BlockCypher.Services;
using ICMarkets.Developer.Clients.BlockCypher.Services.Interfaces;
using ICMarkets.DeveloperTest.API.Infrastructure.APIPolicies;
using ICMarkets.DeveloperTest.API.Infrastructure.Mappers;
using ICMarkets.DeveloperTest.API.Infrastructure.Services;
using ICMarkets.DeveloperTest.API.Infrastructure.Services.Interfaces;
using ICMarkets.DeveloperTest.Datacontext.Repositories;
using ICMarkets.DeveloperTest.Datacontext.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Serilog;
using System.Reflection;
using System.Text.Json.Serialization;
using static ICMarkets.DeveloperTest.API.Infrastructure.APIPolicies.NamingPolicies;

namespace ICMarkets.DeveloperTest.API.Infrastructure.Startup;
public static class ServicesConfiguration
{
    public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
    {
        RegisterLogger(builder);
        RegisterMapper(builder);
        RegisterHttpServices(builder);
        RegisterSwagger(builder);
        RegisterRepositories(builder);
        RegisterDependentServices(builder);
        RegisterConnectedServices(builder);
        return builder;
    }

    private static WebApplicationBuilder RegisterLogger(WebApplicationBuilder builder)
    {
        var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var logger = new LoggerConfiguration().ReadFrom.Configuration(new ConfigurationBuilder()
            .AddJsonFile($"logging-configuration-{env}.json").Build())
            .Enrich.FromLogContext()
            .CreateLogger();
        builder.Logging.ClearProviders();
        builder.Logging.AddSerilog(logger);
        return builder;
    }
    private static WebApplicationBuilder RegisterMapper(WebApplicationBuilder builder)
    {
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new DefaultMapper());
        });
        IMapper mapper = mapperConfig.CreateMapper();
        builder.Services.AddSingleton(mapper);
        return builder;
    }
    private static WebApplicationBuilder RegisterHttpServices(WebApplicationBuilder builder)
    {
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = SnakeCaseNamingPolicy.Policy;
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            options.JsonSerializerOptions.DefaultIgnoreCondition
                       = JsonIgnoreCondition.WhenWritingNull;
        }).AddFluentValidation(options =>
        {
            options.ImplicitlyValidateChildProperties = true;
            options.ImplicitlyValidateRootCollectionElements = true;
            options.DisableDataAnnotationsValidation = true;
            options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        });

        builder.Services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ReportApiVersions = true;
            options.ApiVersionReader = new UrlSegmentApiVersionReader();
        });

        return builder;
    }
    private static WebApplicationBuilder RegisterSwagger(WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        return builder;
    }
    private static WebApplicationBuilder RegisterRepositories(WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IBlockchainDataRepository, BlockchainDataRepository>();
        builder.Services.AddTransient<IRequestRepository, RequestRepository>();
        builder.Services.AddTransient<IExceptionRepository, ExceptionRepository>();
        return builder;
    }
    private static WebApplicationBuilder RegisterDependentServices(WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IAuditLogService, ExceptionAuditLogService>();
        builder.Services.AddTransient<IBlockService, BlockService>();
        return builder;
    }
    private static WebApplicationBuilder RegisterConnectedServices(WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IBlockcypherApiService, BlockcypherApiService>();
        return builder;
    }
}
