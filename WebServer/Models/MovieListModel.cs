namespace WebServer.Models
{
    public class MovieListModel
    {
        public string? Url { get; set; }
        public string title { get; set; }
        public string startYear { get; set; }
        public string endYear { get; set; }
        public float ratingAvergeTitle { get; set; }
        public string poster { get; set; }
        public string plot { get; set; }
        /* This hack did'nt work 
        public string character { get; set; }
        public string category { get; set; }
        */
    }
}
