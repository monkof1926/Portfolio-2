using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class SearchHistorySearchModel
    {
        public string? searchSearch { get; set; }
        public string? searchWord { get; set; }
        public int? searchOrder { get; set; }
        //Add public string? searchUserID { get; set; }
    }
}
