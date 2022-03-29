using Newtonsoft.Json;

namespace Azathoth.Kraken.Models.Responses
{
    public record TradesHistoryResponse
    {
        [JsonProperty("name")]
        public string Name { get; init; }
        [JsonProperty("price")]
        public decimal Price { get; init; }
        [JsonProperty("amount")]
        public decimal Amount { get; init; }
        [JsonProperty("cost")]
        public decimal Cost { get; init; }
    }
}