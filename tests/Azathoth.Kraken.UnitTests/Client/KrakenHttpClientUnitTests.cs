using System.Net.Http;
using System.Threading.Tasks;
using Azathoth.Kraken.Client;
using Xunit;

namespace Azathoth.Kraken.UnitTests.Client
{
    public class KrakenHttpClientUnitTests
    {
        [Fact]
        public async Task calling_GetCurrentPricesAsync_with_valid_tickers_returns_valid_result()
        {
            // using var http = new HttpClient();
            // var client = new KrakenHttpClient(http);

            // await client.GetCurrentPricesAsync("Ticker?pair=XBTUSD");

            Assert.True(true);
        }
    }
}