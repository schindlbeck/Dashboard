namespace Dash.Mongo.Models
{
    public class SessionModel
    {
        public string Location { get; set; }

        public string TransWH { get; set; }

        public DateTime TimeStamp { get; set; } = DateTime.Now;

        public string AuthId { get; set; }

        public string Duration { get; set; }


    }
}
