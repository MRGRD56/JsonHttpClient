using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Mrgrd56.JsonHttpClient.Tests.Models;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Mrgrd56.JsonHttpClient.Tests
{
    public class Tests
    {
        private readonly HttpClient _httpClient = new();
        
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public async Task GetAsyncTest()
        {
            var expectedUserJson = @"
{
    ""id"": 1,
    ""name"": ""Leanne Graham"",
    ""username"": ""Bret"",
    ""email"": ""Sincere@april.biz"",
    ""address"": {
        ""street"": ""Kulas Light"",
        ""suite"": ""Apt. 556"",
        ""city"": ""Gwenborough"",
        ""zipcode"": ""92998-3874"",
        ""geo"": {
            ""lat"": ""-37.3159"",
            ""lng"": ""81.1496""
        }
    },
    ""phone"": ""1-770-736-8031 x56442"",
    ""website"": ""hildegard.org"",
    ""company"": {
        ""name"": ""Romaguera-Crona"",
        ""catchPhrase"": ""Multi-layered client-server neural-net"",
        ""bs"": ""harness real-time e-markets""
    }
}".Trim();
            var expected = JsonConvert.DeserializeObject<User>(expectedUserJson);
            var users = await _httpClient.GetAsync<User[]>("https://jsonplaceholder.typicode.com/users");
            var actual = users.FirstOrDefault();
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(10, users.Length);
        }
    }
}