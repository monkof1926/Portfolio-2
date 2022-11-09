using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Domain
{
    public class Person
    {
        public string nameID { get; set; }
        public string fullName { get; set; }
        public string birthYear { get; set; }
        public string? deathYear { get; set; }
        public float? rating { get; set; }
        public string[,]? featuredIn { get; set; } 
    }
}
