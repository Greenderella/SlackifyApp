using SlackifyApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace SlackifyApp.Controllers
{
    public class TokenGenerator
    {
        Random random = new Random();

        internal dynamic generate()
        {
            string firstAdjective = RandomSelection(HumongousList.adjectives);
            string secondtAdjective = RandomSelection(HumongousList.adjectives);
            string noun = RandomSelection(HumongousList.nouns);
            
            return firstAdjective + "-" + secondtAdjective + "-" + noun;
        }

        private string RandomSelection(List<string> stuffs)
        {
            int rnd = random.Next(0, stuffs.Count);
            return stuffs[rnd];
        }
    }
}