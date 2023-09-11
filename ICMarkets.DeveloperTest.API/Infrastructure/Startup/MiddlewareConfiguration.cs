using ICMarkets.DeveloperTest.API.Infrastructure.Middlewares;
using ICMarkets.DeveloperTest.Datacontext;
using Microsoft.EntityFrameworkCore;

namespace ICMarkets.DeveloperTest.API.Infrastructure.Startup;
public static class MiddlewareConfiguration
{
    public static WebApplication ConfigureMiddleware(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.UseMiddleware(typeof(RequestLoggingMiddleware));
        app.UseMiddleware(typeof(ErrorHandlingMiddleware));
        app.MapControllers();
        ApplyMigrations(app);
        return app;
    }

    private static void ApplyMigrations(WebApplication app)
    {
        using (var serviceScope = app.Services.GetService<IServiceScopeFactory>()!.CreateScope())
        {
            //if (!Debugger.IsAttached)
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ICMarketsDbContext>();
                context.Database.Migrate();
            }
        }
    }
}