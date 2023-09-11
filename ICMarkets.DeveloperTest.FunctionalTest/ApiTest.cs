using ICMarkets.Developer.Shared.Models.Enums;
using ICMarkets.DeveloperTest.API.Controllers;
using ICMarkets.DeveloperTest.API.Infrastructure.Services.Interfaces;
using Moq;

namespace ICMarkets.DeveloperTest.FunctionalTest;
public class ApiTest
{
    [Fact]
    public async Task ApiResponseTest()
    {
        var blockServiceMock = new Mock<IBlockService>();
        var blockchainApiController = new BlockchainController(blockServiceMock.Object);
        var result = await blockchainApiController.Get(BlockTypeEnum.ETH, CancellationToken.None); 
        Assert.NotNull(result);
    }
}