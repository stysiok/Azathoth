using Azathoth.Kraken.Models.Requests;

namespace Azathoth.Kraken.Utils
{
    public interface IKrakenRequestExtensions
    {
        string InlineToParams<T>(T request) where T : IKrakenRequestBase;
    }
}