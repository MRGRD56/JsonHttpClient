using Newtonsoft.Json;

namespace Mrgrd56.JsonHttpClient.Tests.Models
{
    public record Geo(
        [JsonProperty("lat")]
        string Latitude,
        [JsonProperty("lng")]
        string Longitude);
}