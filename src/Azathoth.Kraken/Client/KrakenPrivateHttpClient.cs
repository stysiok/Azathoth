using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Azathoth.Kraken.Models;
using Azathoth.Kraken.Models.Requests;
using Azathoth.Kraken.Utils;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Azathoth.Kraken.Client
{
    public class KrakenPrivateHttpClient : BaseKrakenHttpClient, IPrivateKrakenHttpClient
    {
        private readonly KrakenAPIOptions _options;
        private readonly ISignatureCreator _signatureCreator;
        
        public KrakenPrivateHttpClient(HttpClient client, IOptions<KrakenAPIOptions> options) : base(client)
        {
            _options = options.Value;
            _signatureCreator = new SignatureCreator();

            _client.BaseAddress = new Uri($"{_client.BaseAddress.AbsoluteUri}private/");
            _client.DefaultRequestHeaders.Add("API-key", options.Value.Key);
        }

        public async Task GetCurrentBalance()
        {
            var request = new PrivateKrakenRequestBase();
            var signature = _signatureCreator.CreateSignature($"/0/private/Balance", $"nonce={request.Nonce}", request.Nonce, _options.Secret);
            _client.DefaultRequestHeaders.Add("API-Sign", signature);
            var cont = new StringContent($"nonce={Uri.EscapeDataString(request.Nonce.ToString())}", Encoding.UTF8, "application/x-www-form-urlencoded");
            var response = await _client.PostAsync($"Balance", cont);

            var content = await response.Content.ReadAsStringAsync();
        }
    }
}