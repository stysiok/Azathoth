using System.Threading.Tasks;

namespace Azathoth.Kraken.Client
{
    public interface IKrakenHttpClient
    {
        Task GetCurrentPricesAsync(string tickers);
    }
}