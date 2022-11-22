using DataLayer.Domain;
using DataLayer.Models;

namespace DataLayer.IDataService
{
    public interface IRatingHistoryMovieDataService
    {
        IList<RatingHistoryMovie> GetRatingHistoryMovies(int page, int pageSize);
        RatingHistoryMovie? GetRatingHistoryMovie(string ratingHisMovTID);
        void CreateRatingHistoryMovie(RatingHistoryMovie ratingHistoryM);
        bool UpdateRatingHistoryMovie(RatingHistoryMovie ratingHistoryM);
        bool DeleteRatingHistoryMovie(string ratingHisMovTID);
        int GetNumberOfUserRatingHist();
        IList<RatingHistoryMovieSearchModel> GetRatingHistoryMovieByUser(string search);
        //RatingHistoryPerson CreateUser(string username, string password = null);
    }
}
