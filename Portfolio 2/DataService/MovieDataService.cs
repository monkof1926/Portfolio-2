using DataLayer;
using DataLayer.Domain;
using DataLayer.IDataService;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;


namespace DataLayer.DataService
{
    public class MovieDataService : IMovieDataService
    {
        public void CreateMovie(Movie movie)
        {
            using var db = new NorthwindContext();
            db.title_basics.Add(movie);
            db.SaveChanges();
        }
        public bool DeleteMovie(string movieID)
        {
            using var db = new NorthwindContext();
            var movie = db.title_basics.Find(movieID);
            if (movie != null)
            {
                db.title_basics.Remove(movie);
            }
            else { return false; }

            return db.SaveChanges() > 0;
        }
        //This is a hack to make the get movies to work trying to make a better solution
        public IList<Movie> GetMovies(int page, int pageSize)
        {
            using var db = new NorthwindContext();
            var titles = db.title_basics
                .Skip(page * pageSize)
                .Take(pageSize)
                .OrderBy(x => x.movieID)
                .ToList();

            var ratingService = new RatingMovieDataService();
            var movieOMDB = new OmdbDataService();

            foreach (var t in titles)
            {
                t.Rating = ratingService.GetRatingsMovie(t.movieID);
                t.omdb = movieOMDB.GetOmdb(t.movieID);
            }

            return titles;


            //return db.title_ratings.ToList();
        }
        public Movie GetMovie(string movieID)
        {
            using var db = new NorthwindContext();
            if (movieID != null)
            {
                var movie = db.title_basics.FirstOrDefault(x => x.movieID == movieID);
                var ratingService = new RatingMovieDataService();

                movie.Rating = ratingService.GetRatingsMovie(movieID);

                var movieOMDB = new OmdbDataService();

                movie.omdb = movieOMDB.GetOmdb(movieID);

                return movie;
            }
            return null;
        }
        public bool UpdateMovie(Movie movie)
        {
            using var db = new NorthwindContext();
            var dbMovie = db.title_basics.Find(movie.movieID);
            if (dbMovie == null) return false;
            dbMovie.movieID = movie.movieID;
            dbMovie.title = movie.title;
            db.SaveChanges();
            return true;
        }
        public int GetNumberOfMovies()
        {
            using var db = new NorthwindContext();
            return db.title_basics.Count();
        }
        public IList<MovieSearchModel> GetMovieSearches(string searchMovie)
        {
            using var db = new NorthwindContext();

            return db.title_basics
                .Include(x => x.title)
                .Where(x => x.title == searchMovie)
                .Select(x => new MovieSearchModel
                {
                    movieTitle = x.title,
                })
                .ToList();
        }
    }
}
