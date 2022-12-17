using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Domain
{
    public class Person
    {
        public string? nameID { get; set; }
        public string? fullName { get; set; }
        public string? birthYear { get; set; }
        public string? deathYear { get; set; }

        [NotMapped]
        public CharatersPlayed? charaters_played { get; set; }
       
    }
}
