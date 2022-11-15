﻿using DataLayer.Domain;


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
    }
}
