using Azathoth.Kraken.Models.Requests;

namespace Azathoth.Kraken.Utils
{
    public interface ISignatureCreator
    {
        string CreateSignature<T>(string pathname, string secret, T request) where T : PrivateKrakenRequestBase;
    }
}