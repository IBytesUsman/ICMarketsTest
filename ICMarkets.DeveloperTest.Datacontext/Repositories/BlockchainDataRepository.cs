using ICMarkets.DeveloperTest.Datacontext.DOs;
using ICMarkets.DeveloperTest.Datacontext.Entities;
using ICMarkets.DeveloperTest.Datacontext.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ICMarkets.DeveloperTest.Datacontext.Repositories;
public class BlockchainDataRepository : IBlockchainDataRepository
{
    private readonly ICMarketsDbContext _dbContext;
    public BlockchainDataRepository(ICMarketsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<BlockchainDataEntity>> QueryAsync(BlockchainDataQueryDo query, CancellationToken cancellationToken)
    {
        try
        {
            var dbQuery = _dbContext.BlockchainData.AsQueryable();
            if (query.Type is not null)
                dbQuery = dbQuery.Where(x => x.Type == query.Type.Value);
            dbQuery = dbQuery.OrderByDescending(x => x.CreatedAt);
            if (query.Limit > -1)
                dbQuery = dbQuery.Take(query.Limit);
            if (!query.Tracking)
                dbQuery = dbQuery.AsNoTracking();

            return await dbQuery.ToListAsync(cancellationToken);
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<BlockchainDataEntity> CreateAsync(BlockchainDataEntity entity, CancellationToken cancellationToken)
    {
        try
        {
            var tracking = await _dbContext.BlockchainData.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return tracking.Entity;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
