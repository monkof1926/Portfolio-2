namespace DataLayer.Domain
{
    public class RatingPerson
    {
        public string? ratingnconst { get; set; }
        public float? ratingAvergePerson { get; set; }
        public int ratingNumPerson { get; set; }
        
        //public string? ratingUserID { get; set; }
        //We didn't prioritize adding the ratingUserID to the SQL database
    }
}
