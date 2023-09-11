using ICMarkets.Developer.Shared.Models.DTO;
using ICMarkets.Developer.Shared.Models.Enums;
using ICMarkets.DeveloperTest.API.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ICMarkets.DeveloperTest.API.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class BlockchainController : ControllerBase
{
    private readonly IBlockService _blockService;
    public BlockchainController(IBlockService blockService)
    {
        _blockService = blockService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(NotFoundResult), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BlockDataDTO), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(BlockTypeEnum? blockType, CancellationToken cancellationToken)
    {
        if (blockType is null)
            return BadRequest("Invalid Block type requested.");

        var blockData = await _blockService.GetBlockDataAsync(blockType.Value, cancellationToken);
        return (blockData is null) ?
            NotFound() :
            Ok(blockData);
    }

    [HttpGet("history")]
    [ProducesResponseType(typeof(NotFoundResult), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BlockDataDTO), StatusCodes.Status200OK)]
    public async Task<IActionResult> History(BlockTypeEnum? blockType, CancellationToken cancellationToken)
    {
        if (blockType is null)
            return BadRequest("Invalid Block type requested.");

        var blockHistory = await _blockService.GetBlockDataHistoryAsync(blockType.Value, cancellationToken);
        return Ok(blockHistory);
    }
}