using DataLayer.Domain;

namespace DataLayer.IDataService
{
    public interface IRatingDataService
    {
        IList<Rating> GetRatings();
        Rating GetRatings(string ratingnconst, string ratingtonst);
        void CreateRatingPerson(Rating ratingP);
        bool UpdateRatingPerson(Rating ratingP);
        bool DeleteRatingPerson(string ratingnconst);
        void CreateRatingMovie(Rating ratingM);
        bool UpdateRatingMovie(Rating ratingM);
        bool DeleteRatingMovie(string ratingtonst);
    }
}
