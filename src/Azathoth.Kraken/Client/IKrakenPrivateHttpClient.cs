using System.Collections.Generic;
using System.Threading.Tasks;
using Azathoth.Kraken.Models.Requests;
using Azathoth.Kraken.Models.Responses;

namespace Azathoth.Kraken.Client
{
    public interface IPrivateKrakenHttpClient
    {
        Task GetCurrentBalance();
        Task<IEnumerable<TradesHistoryResponse>> GetTradesHistory(TradesHistoryRequest request); 
    }
}