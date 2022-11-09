using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Domain
{
    public class Movie
    {
        public string movieID{ get; set; }
        public string title{ get; set; }
        public string startYear{ get; set; }
        public string endYear{ get; set; }
        public float? rating { get; set; }
    }
}
