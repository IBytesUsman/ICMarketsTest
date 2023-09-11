using ICMarkets.DeveloperTest.Datacontext.Entities;
using ICMarkets.DeveloperTest.Datacontext.Repositories.Interfaces;

namespace ICMarkets.DeveloperTest.Datacontext.Repositories;
public class ExceptionRepository : IExceptionRepository
{
    private readonly ICMarketsDbContext _dbContext;
    public ExceptionRepository(ICMarketsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public  async Task<ExceptionEntity> CreateAsync(ExceptionEntity entity, CancellationToken cancellationToken)
    {
        try
        {
            var tracking = await _dbContext.ExceptionsAudit.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return tracking.Entity;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
