using DataLayer.Models;
using DataLayer.Domain;


namespace DataLayer.IDataService
{
    public interface IMovieDataService
    {
        IList<Movie> GetMovies(int page, int pageSize);
        //IList<RatingMovie> GetMovies(int page, int pageSize);
        Movie? GetMovie(string movieID);
        void CreateMovie(Movie movie);
        bool UpdateMovie(Movie movie);
        bool DeleteMovie(string movieID);
        int GetNumberOfMovies();
        IList<MovieSearchModel> GetMovieSearches(string searchMovie);
    }
}
