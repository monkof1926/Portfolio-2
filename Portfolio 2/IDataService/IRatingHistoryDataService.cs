using DataLayer.Domain;


namespace DataLayer.IDataService
{
    public interface IRatingHistoryDataService
    {
        IList<RatingHistory> GetRatingHistoriesPers(int page, int pageSize);
        IList<RatingHistory> GetRatingHistoriesMov(int page, int pageSize);
        RatingHistory? GetRatingHistoryPers(string ratingHisPersonNID);
        RatingHistory? GetRatingHistoryMov(string ratingHisMovTID);
        void CreateRatingHistoryPerson(RatingHistory ratingHistoryP);
        bool UpdateRatingHistoryPerson(RatingHistory ratingHistoryP);
        bool DeleteRatingHistoryPerson(string ratingHisPersonNID);
        void CreateRatingHistoryMovie(RatingHistory ratingHistoryM);
        bool UpdateRatingHistoryMovie(RatingHistory ratingHistoryM);
        bool DeleteRatingHistoryMovie(string ratingHisMovTID);
    }
}
