using SlackifyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SlackifyApp.Controllers
{
    public class TokenGenerator
    {
        public Random random = new Random();
        private ConfigureDBContext _db = new ConfigureDBContext();

        public string generate()
        {
            string possibleToken;
            do
            {
                possibleToken = generateUnsafe();
            } while (existInDB(possibleToken));
            return possibleToken;
        }

        private string RandomSelection(List<string> stuffs)
        {
            int rnd = random.Next(0, stuffs.Count);
            return stuffs[rnd];
        }

        private string generateUnsafe()
        {
            string firstAdjective = RandomSelection(HumongousList.adjectives);
            string secondtAdjective = RandomSelection(HumongousList.adjectives);
            string noun = RandomSelection(HumongousList.nouns);
            
            return firstAdjective + "-" + secondtAdjective + "-" + noun;
        }

        private bool existInDB(string aBuscar)
        {
            return _db.DB.Any(b => b.endpoint == aBuscar);
        }

    }
}