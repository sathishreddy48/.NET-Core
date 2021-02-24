using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json.Linq;
using Xunit;

namespace WebApiTask.Test
{
    public class QnATest
    {
        private readonly HttpClient _client;

        public QnATest()
        {
            // Arrange
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = server.CreateClient();
            _client.BaseAddress = new System.Uri("https://localhost:44332");
        }

        [Fact]
        public async Task ReturnCollection()
        {
            var response = _client.GetAsync("/api/GetQuestions").Result;
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            dynamic collection = JObject.Parse(await response.Content.ReadAsStringAsync());
            Assert.True(collection.value.Count > 0);
        }
    }
}
