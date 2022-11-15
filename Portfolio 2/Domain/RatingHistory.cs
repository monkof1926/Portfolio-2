using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Domain
{
    public class RatingHistory
    {
        public string ratingHisMovTID { get; set; }
        public float ratingHisMovRating { get; set; }
        public string ratingHisMovTconst { get; set; }
        public string ratingHisPersonNID { get; set; }
        public float ratingHisPersonRating { get; set; }
        public string ratingHisPersonNconst { get; set; }
        public string ratingHisUserID { get; set; }
    }
}
