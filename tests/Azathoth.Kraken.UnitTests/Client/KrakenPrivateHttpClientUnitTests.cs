using System.Net.Http;
using System.Threading.Tasks;
using Azathoth.Kraken.Client;
using Azathoth.Kraken.Models;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace Azathoth.Kraken.UnitTests.Client
{
    public class KrakenPrivateHttpClientUnitTests
    {
        [Fact]
        public async Task GetCurrentBalance_returns_accurate_balance()
        {
            var optionsMock = new Mock<IOptions<KrakenAPIOptions>>();
            var krakenApiOptionsMock = new Mock<KrakenAPIOptions>();
            krakenApiOptionsMock.Setup(x => x.Key).Returns("...");
            krakenApiOptionsMock.Setup(x => x.Secret).Returns("...");
            optionsMock.Setup(o => o.Value).Returns(krakenApiOptionsMock.Object);
            var client = new KrakenPrivateHttpClient(new HttpClient(), optionsMock.Object);

            await client.GetCurrentBalance();
        }
    }
}