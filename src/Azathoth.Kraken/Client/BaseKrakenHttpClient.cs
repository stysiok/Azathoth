using System;
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
    public abstract class BaseKrakenHttpClient
    {
        protected readonly HttpClient _client;
        private readonly ISignatureCreator _signatureCreator;
        private readonly KrakenAPIOptions _options;
        private readonly IKrakenRequestExtensions _extensions;

        public BaseKrakenHttpClient(HttpClient client, IOptions<KrakenAPIOptions> options)
        {
            _signatureCreator = new SignatureCreator();
            _extensions = new KrakenRequestExtensions();
            _options = options.Value;

            _client = client;
            _client.BaseAddress = new Uri("https://api.kraken.com/0/");
            _client.DefaultRequestHeaders.Add("User-Agent", "test-api-c#-client");        
        }

        public virtual async Task<KrakenResponse<T>> PostAsync<R, T>(string pathname, R request) where R : IKrakenRequestBase
        {
            if(request is PrivateKrakenRequestBase privateRequest)
            {
                var signature = _signatureCreator.CreateSignature($"{_client.BaseAddress.AbsoluteUri}{pathname}", _options.Secret, privateRequest);
                _client.DefaultRequestHeaders.Add("API-Sign", signature);
            }
            var cont = new StringContent(_extensions.InlineToParams(request), Encoding.UTF8, "application/x-www-form-urlencoded");
            var response = await _client.PostAsync(pathname, cont);

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<KrakenResponse<T>>(content);
        }
    }
}