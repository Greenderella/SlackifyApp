using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;

namespace SlackifyApp.Tests.Model.Http
{
    [TestClass]
    public class HttpClientTest
    {
        [TestMethod]
        public void http_client_can_get_stuff()
        {
            SimpleHttpClient client = new SimpleHttpClient
            {
                BaseAddress = new Uri("http://table-flip.herokuapp.com/")
            };

            string response = client.Get("hercules");

            Assert.AreEqual("(/ .□.) ︵╰(゜Д゜)╯︵ /(.□. )", response);
        }

        [TestMethod]
        public void http_client_can_get_stuff_without_base_url()
        {
            SimpleHttpClient client = new SimpleHttpClient();

            string response = client.Get("http://table-flip.herokuapp.com/hercules");

            Assert.AreEqual("(/ .□.) ︵╰(゜Д゜)╯︵ /(.□. )", response);
        }
    }
}