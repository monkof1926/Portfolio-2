using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Domain
{
    public class Movie
    {
        public string movieID{ get; set; }
        public string title{ get; set; }
        public string startYear{ get; set; }
        public string endYear{ get; set; }
        //public float? rating { get; set; }
        [NotMapped]
        public RatingMovie? Rating { get; set; }
        public float? rating { get; set; }
        public string description { get; set; }
        public object image { get; set; }
    }
}
