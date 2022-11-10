using Portfolio_2.Models;
using DataLayer.Domain;


namespace Portfolio_2.IDataService
{
    public interface IMovieDataService
    {
        IList<Movie> GetMovies(int page, int pageSize);
        Movie? GetMovies(string movieID);
        void CreateMovie(Movie movie);
        bool UpdateMovie(Movie movie);
        bool DeleteMovie(string movieID);
        int GetNumberOfMovies();
        IList<MovieSearchModel> GetMovieSearches(string searchMovie);
    }
}
