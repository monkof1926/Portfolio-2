using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Domain
{
    public class SearchResult
    {
        public string? tconst{ get; set; }
        public string? pname {get; set; } 
        public string? nconst { get; set; }
        public string? title { get; set; }
        public int? rank { get; set; }
    }
}
