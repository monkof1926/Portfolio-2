using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Domain
{
    public class Movie
    {
        public string movieID { get; set; }
        public string title { get; set; }
        public string startYear { get; set; }
        public string endYear { get; set; }
        //public float? rating { get; set; }
        // this is a hack that allows os to add average rating and omdb to the movie
        [NotMapped]
        public RatingMovie? Rating { get; set; }
        [NotMapped]
        public Omdb? omdb { get; set; }
        /* this hack did'nt work 
        [NotMapped]
        public CharatersPlayed? characters_played { get; set; }
        */
    }
}
