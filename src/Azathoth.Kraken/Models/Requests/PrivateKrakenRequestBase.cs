using System;
using Newtonsoft.Json;

namespace Azathoth.Kraken.Models.Requests
{
    public record PrivateKrakenRequestBase : IKrakenRequestBase
    {
        [JsonProperty("nonce")]
        public virtual long Nonce { get; private set; }

        public PrivateKrakenRequestBase()
        {
            Nonce = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        }
    }
}