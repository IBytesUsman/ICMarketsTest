using ICMarkets.Developer.Shared.Models.Enums;

namespace ICMarkets.DeveloperTest.Datacontext.DOs; 
public class BlockchainDataQueryDo : BaseQueryDo
{
    public BlockTypeEnum? Type { get; set; }
}
