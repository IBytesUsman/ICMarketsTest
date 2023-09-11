using ICMarkets.Developer.Shared.Models.DTO;
using ICMarkets.Developer.Shared.Models.Enums;

namespace ICMarkets.DeveloperTest.API.Infrastructure.Services.Interfaces;
public interface IBlockService
{
    Task<BlockDataDTO?> GetBlockDataAsync(BlockTypeEnum blockType, CancellationToken cancellationToken);
    Task<IEnumerable<BlockDataDTO>> GetBlockDataHistoryAsync(BlockTypeEnum blockType, CancellationToken cancellationToken);
}
