using System;
using Newtonsoft.Json;

namespace Azathoth.Kraken.Models.Requests
{
    public abstract class PrivateKrakenRequest
    {
        [JsonProperty("nonce")]
        public virtual long Nonce { get; private set; }

        public PrivateKrakenRequest()
        {
            Nonce = DateTimeOffset.Now.ToUnixTimeSeconds();
        }
    }
}