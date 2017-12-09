namespace SlackifyApp.Controllers
{
    public class SlackAttachment
    {

        public SlackAttachment(string text)
        {
            this.text = text;
        }

        public string text { get; set; }
    }
}