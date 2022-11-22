using DataLayer.Domain;
using DataLayer.IDataService;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.DataService
{
    public class RatingHistoryMovieDataService : IRatingHistoryMovieDataService
    {
        public IList<RatingHistoryMovie> GetRatingHistoryMovies(int page, int pageSize)
        {
            using var db = new NorthwindContext();
            return db.title_ratings_hist
                .Include(x => x.ratingHisMovRating)
                .Skip(page * pageSize)
                .Take(pageSize)
                .OrderBy(x => x.ratingHisMovTID)
                .ToList();
        }
        public RatingHistoryMovie? GetRatingHistoryMovie(string ratingHisMovTID)
        {
            using var db = new NorthwindContext();
            return db.title_ratings_hist.Find(ratingHisMovTID);
        }
        public void CreateRatingHistoryMovie(RatingHistoryMovie ratingHistory)
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
        public bool UpdateRatingHistoryMovie(RatingHistoryMovie ratingHistory)
        {
            using var db = new NorthwindContext();
            var dbRatingHisMovie = db.title_ratings_hist.Find(ratingHistory.ratingHisMovTID);
            if (dbRatingHisMovie == null) return false;
            dbRatingHisMovie.ratingHisMovRating = ratingHistory.ratingHisMovRating;
            dbRatingHisMovie.ratingHisMovTconst = ratingHistory.ratingHisMovTconst;
            db.SaveChanges();
            return true;
        }
        public IList<RatingHistoryMovieSearchModel> GetRatingHistoryMovieByUser(string search)
            {
                using var db = new NorthwindContext();
                return db.title_ratings_hist
                    .Include(x => x.ratingHisMovTID)
                    .Where(x => x.ratingHisMovTID == search)
                    .Select(x => new RatingHistoryMovieSearchModel
                    {
                        ratingHistoryMovieUserID = x.ratingHisMovTID
                    })
                    .ToList();
            }
        public int GetNumberOfUserRatingHist()
        {
            using var db = new NorthwindContext();
            return db.title_ratings_hist.Count();
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
