using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Zgadnij_Moja_Liczbe;
using NUnit.Framework;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace NumberGuessingTests
{
    public class GamesControllerTests
    {

        //private readonly HttpClient client;

        //[SetUp]
        //public void SetUp()
        //{
        //}

        [Test]
        public async Task Start_ShouldReturnNewGuidAsSessionId()
        {
            using var application = new WebApplicationFactory<Startup>();
            using var client = application.CreateClient();

            var response = await client.GetAsync("/games/start");

            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);

            var result = await Deserialize<Guid>(response.Content);

            Assert.NotNull(result);
        }

        private static async Task<T> Deserialize<T>(HttpContent content)
        {
            var contentStream = await content.ReadAsStreamAsync();

            using var streamReader = new StreamReader(contentStream);
            using var jsonReader = new JsonTextReader(streamReader);

            JsonSerializer serializer = new JsonSerializer();

            return serializer.Deserialize<T>(jsonReader);
        }
    }
}
