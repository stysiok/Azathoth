using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Azathoth.Kraken.Client
{
    public class KrakenPrivateHttpClient : BaseKrakenHttpClient, IPrivateKrakenHttpClient
    {
        private readonly HttpClient _client;

        public KrakenPrivateHttpClient(HttpClient client) : base(client)
        {
            
        }

        public async Task GetBudget()
        {
            var response = await _client.GetFromJsonAsync<object>("private/balance");
        }

        public async Task GetCurrentPricesAsync()
        {
            // var data = await _client.GetStringAsync();
        }

        public Task GetCurrentPricesAsync(string tickers)
        {
            throw new NotImplementedException();
        }
    }
}