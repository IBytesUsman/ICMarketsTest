using ICMarkets.DeveloperTest.Datacontext.DOs;
using ICMarkets.DeveloperTest.Datacontext.Entities;

namespace ICMarkets.DeveloperTest.Datacontext.Repositories.Interfaces;
public interface IBlockchainDataRepository
{
    Task<IEnumerable<BlockchainDataEntity>> QueryAsync(BlockchainDataQueryDo query, CancellationToken cancellationToken);
    Task<BlockchainDataEntity> CreateAsync(BlockchainDataEntity entity, CancellationToken cancellationToken);
}
