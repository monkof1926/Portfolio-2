namespace WebServer.Models
{
    public class MovieModel
    {
        public string? Url { get; set; }
        public string title { get; set; }
        public string startYear { get; set; }
        public string endYear { get; set; }
        public string rating { get; set; }
        public string poster { get; set; }
        public string plot { get; set; }
        public string page { get; set; }
        /* This hack did'nt work 
      public string character { get; set; }
      public string category { get; set; }
      */
    }
}
