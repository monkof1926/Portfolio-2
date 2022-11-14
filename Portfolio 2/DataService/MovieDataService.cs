using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Domain;
using DataLayer.Models;
using DataLayer.IDataService;
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
        public IList<Movie> GetMovies(int page, int pageSize)
        {
            using var db = new NorthwindContext();
            return db.title_basics
                .Include(x => x.title)
                .Skip(page * pageSize)
                .Take(pageSize)
                .OrderBy(x => x.movieID)
                .ToList();
        }
        public Movie? GetMovies(string movieID)
        {
            using var db = new NorthwindContext();
            if (movieID != null)
            {
                return db.title_basics.Find(movieID);
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
                    //startYear = x.Movie.title

                })
                .ToList();
        }
    }
}
