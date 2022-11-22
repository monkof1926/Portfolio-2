using DataLayer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.IDataService
{
    public interface IRatingMovieDataService
    {
        IList<RatingMovie> GetRatingsMovies();
        RatingMovie GetRatingsMovie(string? ratingtonst);
        void CreateRatingMovie(RatingMovie ratingM);
        bool UpdateRatingMovie(RatingMovie ratingM);
        bool DeleteRatingMovie(string ratingtonst);
        // User GetUser(string username, string password = null, string salt = null);
    }
}
