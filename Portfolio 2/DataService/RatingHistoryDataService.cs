using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Domain;
using DataLayer.IDataService;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.DataService
{
    public class RatingHistoryDataService : IRatingHistoryDataService
    {
        public void CreateRatingHistoryPerson(RatingHistory ratingHistoryP)
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
        public IList<RatingHistory> GetRatingHistoryPerson(int page, int pageSize)
        {
            using var db = new NorthwindContext();
            return db.name_ratings_hist
                .Include(x => x.ratingHisPersonRating)
                .Skip(page * pageSize)
                .Take(pageSize)
                .OrderBy(x => x.ratingHisPersonNID)
                .ToList();
        }
        public IList<RatingHistory> GetRatingHistoryMovie(int page, int pageSize)
        {
            using var db = new NorthwindContext();
            return db.title_ratings_hist
                .Include(x => x.ratingHisMovRating)
                .Skip(page * pageSize)
                .Take(pageSize)
                .OrderBy(x => x.ratingHisMovTID)
                .ToList();
        }
        public RatingHistory? GetRatingHistoryPerson(string ratingHisPersonNID)
        {
            using var db = new NorthwindContext();
            return db.name_ratings_hist.Find(ratingHisPersonNID);
        }
        public RatingHistory? GetRatingHistoryMovie(string ratingHisMovTID)
        {
            using var db = new NorthwindContext();
            return db.title_ratings_hist.Find(ratingHisMovTID);
        }
        public bool UpdateRatingHistoryPerson(RatingHistory ratingHistory)
        {
            using var db = new NorthwindContext();
            var dbRatingHistoryPerson = db.name_ratings_hist.Find(ratingHistory.ratingHisPersonNID);
            if (dbRatingHistoryPerson == null) return false;
            dbRatingHistoryPerson.ratingHisPersonRating = ratingHistory.ratingHisPersonRating;
            dbRatingHistoryPerson.ratingHisPersonNconst = ratingHistory.ratingHisPersonNconst;
            db.SaveChanges();
            return true;
        }
        public void CreateRatingHistoryMovie(RatingHistory ratingHistory)
        {
            using var db = new NorthwindContext();
            db.title_ratings_hist.Add(ratingHistory);
            db.SaveChanges();
        }
        public bool DeleteRatingHistoryMovie(string ratingHisMovTID)
        {
            using var db = new NorthwindContext();
            var ratingHisMovie = db.title_ratings_hist.Find(ratingHisMovTID);
            if (ratingHisMovie != null)
            {
                db.title_ratings_hist.Remove(ratingHisMovie);
            }
            else { return false; }

            return db.SaveChanges() > 0;
        }
        public bool UpdateRatingHistoryMovie(RatingHistory ratingHistory)
        {
            using var db = new NorthwindContext();
            var dbRatingHisMovie = db.title_ratings_hist.Find(ratingHistory.ratingHisMovTID);
            if (dbRatingHisMovie == null) return false;
            dbRatingHisMovie.ratingHisMovRating = ratingHistory.ratingHisMovRating;
            dbRatingHisMovie.ratingHisMovTconst = ratingHistory.ratingHisMovTconst;
            db.SaveChanges();
            return true;
        }
        public IList<RatingHistorySearchModel> GetRatingHisByUser(string search)
        {
            using var db = new NorthwindContext();
            return db.name_ratings_hist
                .Include(x => x.ratingHisUserID)
                .Where(x => x.ratingHisUserID == search)
                .Select(x => new RatingHistorySearchModel
                {
                    ratingHisUserID = x.ratingHisUserID
                })
                .ToList();
        }
        public User CreateUser(string username, string password, string salt)
        {
            var user = new User
            {
                username = username,
                password = password,
                salt = salt
            };
        }
    }
}
