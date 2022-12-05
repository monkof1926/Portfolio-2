namespace WebServer.Models
{
    public class MovieModel
    {
        public string? Url { get; set; }
        public int title { get; set; }
        public int startYear { get; set; }
        public int endYear { get; set; }
        public int rating { get; set; }
        public string description { get; set; }
        public object image { get; set; }
    }
}
