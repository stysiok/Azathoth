using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Azathoth.Kraken.Models;
using Azathoth.Kraken.Models.Requests;
using Azathoth.Kraken.Models.Responses;
using Azathoth.Kraken.Utils;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Azathoth.Kraken.Client
{
    public class KrakenPrivateHttpClient : BaseKrakenHttpClient, IPrivateKrakenHttpClient
    {
        public KrakenPrivateHttpClient(HttpClient client, IOptions<KrakenAPIOptions> options) : base(client, options)
        {
            _client.BaseAddress = new Uri($"{_client.BaseAddress.AbsoluteUri}private/");
            _client.DefaultRequestHeaders.Add("API-key", options.Value.Key);
        }

        public async Task GetCurrentBalance()
            => await PostAsync<GetCurrentBalanceRequest, object>("Balance", new GetCurrentBalanceRequest());

        public async Task<IEnumerable<TradesHistoryResponse>> GetTradesHistory(TradesHistoryRequest request)
        {
            var result = await PostAsync<TradesHistoryRequest, TradesHistoryResponse>("TradesHistory", request);

            return result.Data;
        }
    }
}