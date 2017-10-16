using Newtonsoft.Json.Linq;
using System;

namespace SlackifyApp.Model
{
    public class JSONTransformator
    {
        private readonly string configuration;

        public JSONTransformator(string configuration)
        {
            this.configuration = configuration;
        }

        public String Transform(string input)
        {
            return (string)JObject.Parse(input).SelectToken(configuration);
        }
    }
}