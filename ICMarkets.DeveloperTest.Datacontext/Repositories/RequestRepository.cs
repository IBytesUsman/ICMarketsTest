using ICMarkets.DeveloperTest.Datacontext.Entities;
using ICMarkets.DeveloperTest.Datacontext.Repositories.Interfaces;

namespace ICMarkets.DeveloperTest.Datacontext.Repositories;
public class RequestRepository : IRequestRepository
{
    private readonly ICMarketsDbContext _dbContext;
    public RequestRepository(ICMarketsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public  async Task<RequestEntity> CreateAsync(RequestEntity entity, CancellationToken cancellationToken)
    {
        try
        {
            var tracking = await _dbContext.RequestsAudit.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return tracking.Entity;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
