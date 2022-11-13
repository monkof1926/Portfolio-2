using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    internal class MovieSearchModel
    {
        public string? movieTitle { get; set; }
        public string? startYear { get; set; }
        public string? endYear { get; set; }
    }
}
