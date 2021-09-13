using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mrgrd56.JsonHttpClient
{
    public static class HttpContentExtensions
    {
        public static async Task<T> ParseJsonAsync<T>(this HttpContent httpContent)
        {
            var stringContent = await httpContent.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(stringContent);
        }

        public static async Task<JObject> ParseJsonAsync(this HttpContent httpContent)
        {
            return await httpContent.ParseJsonAsync<JObject>();
        }
    }
}