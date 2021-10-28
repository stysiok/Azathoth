using Azathoth.Kraken.Models.Requests;

namespace Azathoth.Kraken.Utils
{
    public interface ISignatureCreator
    {
        string CreateSignature(string pathname, string urlParams, long nonce, string secret);
    }
}