using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    internal class PersonSearchModel
    {
        public string? PersonFullName { get; set; }
        public string? birthYear { get; set; }
        public string? deathYear { get; set; }
    }
}
