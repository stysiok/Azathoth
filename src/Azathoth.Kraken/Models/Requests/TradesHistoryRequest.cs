using Newtonsoft.Json;

namespace Azathoth.Kraken.Models.Requests
{
    public record TradesHistoryRequest : PrivateKrakenRequestBase
    {
        [JsonProperty("ofs")]
        public int Offset { get; set; }
    }
}