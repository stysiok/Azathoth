using System;
using Newtonsoft.Json;

namespace Azathoth.Kraken.Models.Requests
{
    public class PrivateKrakenRequestBase
    {
        [JsonProperty("nonce")]
        public virtual long Nonce { get; private set; }

        public PrivateKrakenRequestBase()
        {
            Nonce = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        }
    }
}