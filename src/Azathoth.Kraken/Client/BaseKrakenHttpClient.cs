using System;
using System.Net.Http;

namespace Azathoth.Kraken.Client
{
    public abstract class BaseKrakenHttpClient
    {
        private readonly HttpClient _client;

        public BaseKrakenHttpClient(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("https://api.kraken.com/0/");
            _client.DefaultRequestHeaders.Add("Content-Type: application/x-www-form-urlencoded", "charset=utf-8");
        }
    }
}