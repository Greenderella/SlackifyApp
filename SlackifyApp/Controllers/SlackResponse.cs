using System.Collections.Generic;

namespace SlackifyApp.Controllers
{
    internal class SlackResponse
    {
        public string text { get; set; }

        public string response_type { get; set; }

        public List<SlackAttachment> attachments { get; set; }

        public SlackResponse(string text)
        {
            this.text = text;
            this.response_type = "in_channel";
            this.attachments = new List<SlackAttachment>{new SlackAttachment("Hola")
            };
        }

        
    }
}