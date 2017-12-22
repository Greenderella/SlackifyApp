using System;
using System.Net.Http;

namespace SlackifyApp.Tests.Model.Http
{
    public class SimpleHttpClient : HttpClient
    {
        public string Get(string url)
        {
            try
            {
                HttpResponseMessage response = this.GetAsync(BaseAddress + url).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                return "Ups, algo salio mal -> " + e.Message;
            }
        }
    }
}