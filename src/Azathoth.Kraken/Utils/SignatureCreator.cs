using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Azathoth.Kraken.Utils
{
    public class SignatureCreator : ISignatureCreator
    {
        public string CreateSignature(string pathname, string urlParams, long nonce, string secret)
        {
            using var sha256 = SHA256.Create();
            var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes($"{nonce.ToString()}{urlParams}"));
            
            using var hmac = new HMACSHA512(Convert.FromBase64String(secret));
            var hmacDigest = hmac.ComputeHash(Encoding.UTF8.GetBytes(pathname).Concat(hash).ToArray());

            return Convert.ToBase64String(hmacDigest);
        }
    }
}