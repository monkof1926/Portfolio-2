using DataLayer.Domain;
using DataLayer.Models;

namespace DataLayer.IDataService
{
    public interface IRatingHistoryPersonDataService
    {
        IList<RatingHistoryPerson> GetRatingHistoryPersons(int page, int pageSize);
        
        RatingHistoryPerson? GetRatingHistoryPerson(string ratingHisPersonNID);
        
        void CreateRatingHistoryPerson(RatingHistoryPerson ratingHistoryP);
        bool UpdateRatingHistoryPerson(RatingHistoryPerson ratingHistoryP);
        bool DeleteRatingHistoryPerson(string ratingHisPersonNID);
       
        int GetNumberOfUserRatingHist();
        IList<RatingHistoryPersonSearchModel> GetRatingHistoryPersonByUser(string search);
       // RatingHistoryPerson CreateUser(string username, string password = null);
    }
}
