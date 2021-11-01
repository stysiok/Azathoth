using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Azathoth.Kraken.Client
{
    public class KrakenHttpClient : BaseKrakenHttpClient, IKrakenHttpClient
    {

        public KrakenHttpClient(HttpClient client) : base(client)
        {
        }

        public Task GetCurrentPricesAsync(string tickers)
        {
            throw new NotImplementedException();
        }
    }
}