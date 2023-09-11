using AutoMapper;
using ICMarkets.Developer.Clients.BlockCypher.Services.Interfaces;
using ICMarkets.Developer.Shared.Models.DTO;
using ICMarkets.Developer.Shared.Models.Enums;
using ICMarkets.DeveloperTest.API.Infrastructure.Services.Interfaces;
using ICMarkets.DeveloperTest.Datacontext.Entities;
using ICMarkets.DeveloperTest.Datacontext.Repositories.Interfaces;

namespace ICMarkets.DeveloperTest.API.Infrastructure.Services;
public class BlockService : IBlockService
{
    private readonly IBlockcypherApiService _blockcypherApiService;
    private readonly IBlockchainDataRepository _blockchainDataRepository;
    private readonly IMapper _mapper;
    public BlockService(
        IBlockcypherApiService blockcypherApiService,
        IBlockchainDataRepository blockchainDataRepository,
        IMapper mapper)
    {
        _blockcypherApiService = blockcypherApiService;
        _blockchainDataRepository = blockchainDataRepository;
        _mapper = mapper;
    }

    public async Task<BlockDataDTO?> GetBlockDataAsync(BlockTypeEnum blockType, CancellationToken cancellationToken)
    {
        var blockData = await _blockcypherApiService.FetchBlockDataAsync(blockType);
        if (blockData is null)
            return null;

        var blockchainEntity = _mapper.Map<BlockchainDataEntity>(blockData);
        blockchainEntity.Type = blockType;
        blockchainEntity = await _blockchainDataRepository.CreateAsync(blockchainEntity, cancellationToken);
        var blockDataDTO = _mapper.Map<BlockDataDTO>(blockchainEntity);
        return blockDataDTO;
    }

    public async Task<IEnumerable<BlockDataDTO>> GetBlockDataHistoryAsync(BlockTypeEnum blockType, CancellationToken cancellationToken)
    {
        var blockchainCollection = await _blockchainDataRepository.QueryAsync(new()
        {
            Type = blockType
        }, cancellationToken);
        var blockchainDTO = _mapper.Map<List<BlockDataDTO>>(blockchainCollection);
        return blockchainDTO;
    }
}