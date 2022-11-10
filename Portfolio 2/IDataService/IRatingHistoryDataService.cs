using Portfolio_2.Models;
using Portfolio_2.Domain;

namespace Portfolio_2.IDataService
{
    public interface IRatingHistoryDataService
    {
        IList<RatingHistory> GetRatingHistories(int page, int pageSize);
        RatingHistory GetRatingHistory(string ratingHisMovTID, string ratingHisPersonNID);
        void CreateRatingHistoryPerson(RatingHistory ratingHistoryP);
        bool UpdateRatingHistoryPerson(RatingHistory ratingHistoryP);
        bool DeleteRatingHistoryPerson(string ratingHisPersonNID);
        void CreateRatingHistoryMovie(RatingHistory ratingHistoryM);
        bool UpdateRatingHistoryMovie(RatingHistory ratingHistoryM);
        bool DeleteRatingHistoryMovie(string ratingHisMovTID);
    }
}
