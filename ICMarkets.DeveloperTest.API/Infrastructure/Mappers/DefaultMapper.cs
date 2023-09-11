using AutoMapper;
using ICMarkets.Developer.Clients.BlockCypher.Models.BlockModels;
using ICMarkets.Developer.Shared.Models.DTO;
using ICMarkets.DeveloperTest.API.Models.Logging;
using ICMarkets.DeveloperTest.Datacontext.Entities;

namespace ICMarkets.DeveloperTest.API.Infrastructure.Mappers;
public class DefaultMapper : Profile
{
	public DefaultMapper()
	{
		CreateMap<RequestAuditModel, RequestEntity>();
        CreateMap<ExceptionAuditModel, ExceptionEntity>();
        CreateMap<EthBlockModel, BlockchainDataEntity>();
        CreateMap<BtcBlockModel, BlockchainDataEntity>();
        CreateMap<DashBlockModel, BlockchainDataEntity>();
        CreateMap<BaseBlockModel, BlockchainDataEntity>();
        CreateMap<BlockchainDataEntity, BlockDataDTO>();
	}
}