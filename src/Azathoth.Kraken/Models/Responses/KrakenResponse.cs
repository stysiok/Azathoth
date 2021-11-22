using System.Collections.Generic;

namespace Azathoth.Kraken.Models.Responses
{
    public record KrakenResponse<T>
    {
        public string[] Errors { get; init; }
        public IEnumerable<T> Data { get; init; }
    }
}