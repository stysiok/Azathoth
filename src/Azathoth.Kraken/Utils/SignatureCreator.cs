using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Azathoth.Kraken.Models.Requests;

namespace Azathoth.Kraken.Utils
{
    public class SignatureCreator : ISignatureCreator
    {
        private readonly IKrakenRequestExtensions _extensions;

        public SignatureCreator()
        {
            _extensions = new KrakenRequestExtensions();
        }

        public string CreateSignature<T>(string pathname, string secret, T request) where T : PrivateKrakenRequestBase
        {
            using var sha256 = SHA256.Create();
            var inlineParams = _extensions.InlineToParams(request);
            var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes($"{request.Nonce.ToString()}{inlineParams}"));
            
            using var hmac = new HMACSHA512(Convert.FromBase64String(secret));
            var hmacDigest = hmac.ComputeHash(Encoding.UTF8.GetBytes(pathname).Concat(hash).ToArray());

            return Convert.ToBase64String(hmacDigest);
        }
    }
}