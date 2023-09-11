using ICMarkets.Developer.Clients.BlockCypher.Models.BlockModels;
using ICMarkets.Developer.Shared.Models.Enums;

namespace ICMarkets.Developer.Clients.BlockCypher.Services.Interfaces;
public interface IBlockcypherApiService
{
    Task<BaseBlockModel?> FetchBlockDataAsync(BlockTypeEnum blockType);
}