using DataLayer.Domain;
using DataLayer.Models;


namespace DataLayer.IDataService
{
    public interface IRatingHistoryDataService
    {
        IList<RatingHistory> GetRatingHistoryPerson(int page, int pageSize);
        IList<RatingHistory> GetRatingHistoryMovie(int page, int pageSize);
        RatingHistory? GetRatingHistoryPerson(string ratingHisPersonNID);
        RatingHistory? GetRatingHistoryMovie(string ratingHisMovTID);
        void CreateRatingHistoryPerson(RatingHistory ratingHistoryP);
        bool UpdateRatingHistoryPerson(RatingHistory ratingHistoryP);
        bool DeleteRatingHistoryPerson(string ratingHisPersonNID);
        void CreateRatingHistoryMovie(RatingHistory ratingHistoryM);
        bool UpdateRatingHistoryMovie(RatingHistory ratingHistoryM);
        bool DeleteRatingHistoryMovie(string ratingHisMovTID);
        int GetNumberOfUserRatingHist();
        IList<RatingHistorySearchModel> GetRatingHisByUser(string search);
        User CreateUser(string username, string password = null, string salt = null);
    }
}
