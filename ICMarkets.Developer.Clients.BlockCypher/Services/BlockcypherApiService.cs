using ICMarkets.Developer.Clients.BlockCypher.Models.BlockModels;
using ICMarkets.Developer.Clients.BlockCypher.Services.Interfaces;
using ICMarkets.Developer.Shared.Models.Enums;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ICMarkets.Developer.Clients.BlockCypher.Services;
public class BlockcypherApiService : IBlockcypherApiService
{
    private readonly string _baseApi;
    public BlockcypherApiService(IConfiguration configuration)
    {
        _baseApi = configuration.GetSection("ConnectedServices:BlockCypher").Value!;
    }

    public async Task<BaseBlockModel?> FetchBlockDataAsync(BlockTypeEnum blockType)
    {
        using (var client = new HttpClient())
        {
            var request = new HttpRequestMessage(HttpMethod.Get, GenerateUrl(blockType));
            var response = await client.SendAsync(request);
            if (!response.IsSuccessStatusCode)
                return null;
            var responseString = await response.Content.ReadAsStringAsync();
            return DeserializeToModel(blockType, responseString);
        }
    }

    private string GenerateUrl(BlockTypeEnum blockType)
    {
        var endPoint = string.Empty;
        switch (blockType)
        {
            case BlockTypeEnum.ETH:
                endPoint = "eth";
                break;
            case BlockTypeEnum.DASH:
                endPoint = "dash";
                break;
            case BlockTypeEnum.BTC:
                endPoint = "btc";
                break;
            default:
                endPoint = string.Empty;
                break;
        }

        return _baseApi.Replace("{endpoint}", endPoint);
    }
    private BaseBlockModel? DeserializeToModel(BlockTypeEnum blockType, string content)
    {
        switch (blockType)
        {
            case BlockTypeEnum.ETH:
                return JsonConvert.DeserializeObject<EthBlockModel>(content);
            case BlockTypeEnum.DASH:
                return JsonConvert.DeserializeObject<DashBlockModel>(content);
            case BlockTypeEnum.BTC:
                return JsonConvert.DeserializeObject<BtcBlockModel>(content);
            default:
                return null;
        }
    }
}