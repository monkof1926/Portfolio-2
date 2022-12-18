using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Domain
{
    public class Person
    {
        public string? nameID { get; set; }
        public string? fullName { get; set; }
        public string? birthYear { get; set; }
        public string? deathYear { get; set; }
        /* This hack don't work as not all people in name_basics have a charaters that they have played but more work 
        [NotMapped]
        public CharatersPlayed? characters_played { get; set; }
        */
       
    }
}
