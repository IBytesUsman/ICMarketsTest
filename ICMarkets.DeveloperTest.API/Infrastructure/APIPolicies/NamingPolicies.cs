using ICMarkets.DeveloperTest.API.Infrastructure.Extensions;
using System.Text.Json;

namespace ICMarkets.DeveloperTest.API.Infrastructure.APIPolicies;
public class NamingPolicies
{
    public class SnakeCaseNamingPolicy : JsonNamingPolicy
    {
        public static SnakeCaseNamingPolicy Policy { get; } = new SnakeCaseNamingPolicy();

        public override string ConvertName(string name)
        {
            return name.ToSnakeCase();
        }
    }
}
