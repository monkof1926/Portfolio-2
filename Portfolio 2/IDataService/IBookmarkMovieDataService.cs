using DataLayer.Domain;



namespace DataLayer.IDataService
{
    public interface IBookmarkMovieDataService 
    {
        IList<BookmarksMovie> GetBookmarksMovies();
        BookmarksMovie? GetBookmarksMovie(string bookmarkMovieBID);
        void CreateBookmarksMovie(BookmarksMovie bookmarksM);
        bool UpdateBookmarksMovie(BookmarksMovie bookmarksM);
        bool DeleteBookmarksMovie(string bookmarkMovieBID);
       // User CreateUser(string username, string password = null);
    }
}
