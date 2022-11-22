using DataLayer.Domain;
using DataLayer.IDataService;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.DataService
{
    public class RatingHistoryPersonDataService : IRatingHistoryPersonDataService
    {
        public void CreateRatingHistoryPerson(RatingHistoryPerson ratingHistoryP)
        {
            
            using var db = new NorthwindContext();
            db.name_ratings_hist .Add(ratingHistoryP);
            db.SaveChanges();
        }
        public bool DeleteRatingHistoryPerson(string ratingHisPersonNID)
        {
            using var db = new NorthwindContext();
            var ratingP = db.name_ratings_hist.Find(ratingHisPersonNID);
            if (ratingP != null)
            {
                db.name_ratings_hist.Remove(ratingP);
            }
            else { return false; }

            return db.SaveChanges() > 0;
        }
        public IList<RatingHistoryPerson> GetRatingHistoryPersons(int page, int pageSize)
        {
            using var db = new NorthwindContext();
            return db.name_ratings_hist
                .Include(x => x.ratingHisPersonRating)
                .Skip(page * pageSize)
                .Take(pageSize)
                .OrderBy(x => x.ratingHisPersonNID)
                .ToList();
        }
      
        public RatingHistoryPerson? GetRatingHistoryPerson(string ratingHisPersonNID)
        {
            using var db = new NorthwindContext();
            return db.name_ratings_hist.Find(ratingHisPersonNID);
        }
       
        public bool UpdateRatingHistoryPerson(RatingHistoryPerson ratingHistory)
        {
            using var db = new NorthwindContext();
            var dbRatingHistoryPerson = db.name_ratings_hist.Find(ratingHistory.ratingHisPersonNID);
            if (dbRatingHistoryPerson == null) return false;
            dbRatingHistoryPerson.ratingHisPersonRating = ratingHistory.ratingHisPersonRating;
            dbRatingHistoryPerson.ratingHisPersonNconst = ratingHistory.ratingHisPersonNconst;
            db.SaveChanges();
            return true;
        }
        
       
        public IList<RatingHistoryPersonSearchModel> GetRatingHistoryPersonByUser(string search)
        {
            using var db = new NorthwindContext();
            return db.name_ratings_hist
                .Include(x => x.ratingHisPersonNID)
                .Where(x => x.ratingHisPersonNID == search)
                .Select(x => new RatingHistoryPersonSearchModel
                {
                    ratingHistoryPersonUserID = x.ratingHisPersonNID
                })
                .ToList();
        }
        public int GetNumberOfUserRatingHist()
        {
            using var db = new NorthwindContext();
            return db.name_ratings_hist.Count();
        }
       /* public User CreateUser(string username, string password)
        {
            var user = new User
            {
                username = username,
                password = password
            };
            return user;
        }*/
    }
}
