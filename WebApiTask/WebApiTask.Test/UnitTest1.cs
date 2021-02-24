using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json.Linq;
using Xunit;

namespace WebApiTask.Test
{
    public class UnitTest1
    {
        private readonly HttpClient client;

        public UnitTest1()
        {
            // Arrange
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            client = server.CreateClient();
        }

        [Fact]
        public async Task GetQuestions()
        {
            var response = await client.GetAsync("https://localhost:44332/api/GetQuestions");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            dynamic collection = JObject.Parse(await response.Content.ReadAsStringAsync());
            Assert.True(collection.value.Count > 0);
        }

        [Fact]
        public async Task GetQuestionsByTag()
        {
            var response = await client.GetAsync("https://localhost:44332/api/Questions/GetQuestionsByTags/c");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            dynamic collection = JObject.Parse(await response.Content.ReadAsStringAsync());
            Assert.True(collection.value.Count > 0);

        }
    }
}
