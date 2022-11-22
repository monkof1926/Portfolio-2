using DataLayer.Domain;

namespace DataLayer.IDataService
{
    public interface IRatingPersonDataService
    {
        IList<RatingPerson> GetRatingsPersons();
        
        RatingPerson GetRatingsPerson(string? ratingnconst);
        void CreateRatingPerson(RatingPerson ratingP);
        bool UpdateRatingPerson(RatingPerson ratingP);
        bool DeleteRatingPerson(string ratingnconst);
       // User GetUser(string username, string password = null, string salt = null);
    }
}
