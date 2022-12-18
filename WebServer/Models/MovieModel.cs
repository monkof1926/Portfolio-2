namespace WebServer.Models
{
    public class MovieModel
    {
        public string? Url { get; set; }
        public int title { get; set; }
        public int startYear { get; set; }
        public int endYear { get; set; }
        public int rating { get; set; }
        public string poster { get; set; }
        public string plot { get; set; }
        /* This hack did'nt work 
      public string character { get; set; }
      public string category { get; set; }
      */
    }
}
