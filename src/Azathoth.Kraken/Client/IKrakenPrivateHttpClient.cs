using System.Threading.Tasks;

namespace Azathoth.Kraken.Client
{
    public interface IPrivateKrakenHttpClient
    {
        Task GetCurrentBalance();
    }
}