using System.Linq;
using Azathoth.Kraken.Models.Requests;

namespace Azathoth.Kraken.Utils
{
    public class KrakenRequestExtensions : IKrakenRequestExtensions
    {
        public string InlineToParams<T>(T request) where T : IKrakenRequestBase
        {
            var type = request.GetType();
            var props = type.GetProperties();
            var nameValue = props.Select(p => {
                var name = p.Name.ToLowerInvariant();
                var value = p.GetValue(request);
                return $"{name}={value}";
            });
            var inlinedParams = string.Join('&', nameValue);

            return inlinedParams;
        }
    }
}