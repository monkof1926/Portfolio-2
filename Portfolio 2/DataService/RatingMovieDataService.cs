using DataLayer.Domain;
using DataLayer.IDataService;

namespace DataLayer.DataService
{
    public class RatingMovieDataService : IRatingMovieDataService
    {
        public void CreateRatingMovie(RatingMovie rating)
        {
            using var db = new NorthwindContext();
            db.title_ratings.Add(rating);
            db.SaveChanges();
        }
        public RatingMovie? GetRatingsMovie(string ratingAvergeTitle)
        {
            using var db = new NorthwindContext();
            return db.title_ratings.Find(ratingAvergeTitle);
        }
        public IList<RatingMovie> GetRatingsMovies()
        {
            using var db = new NorthwindContext();
            return db.title_ratings.ToList();
        }
        public bool DeleteRatingMovie(string ratingtonst)
        {
            using var db = new NorthwindContext();
            var ratingM = db.title_ratings.Find(ratingtonst);
            if (ratingM != null)
            {
                db.title_ratings.Remove(ratingM);
            }
            else { return false; }

            return db.SaveChanges() > 0;
        }
        public bool UpdateRatingMovie(RatingMovie rating)
        {
            using var db = new NorthwindContext();
            var dbRatingMovie = db.title_ratings.Find(rating.ratingtonst);
            if (dbRatingMovie == null) return false;
            dbRatingMovie.ratingtonst = rating.ratingtonst;
            dbRatingMovie.ratingAvergeTitle = rating.ratingAvergeTitle;
            db.SaveChanges();
            return true;
        }
        /* public User CreateUser(string username, string password)
        {
            var user = new User
            {
                username = username,
                password = password,
            };
            return user;
        }*/
    }
}
