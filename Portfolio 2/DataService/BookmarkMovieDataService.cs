using DataLayer;
using DataLayer.Domain;
using DataLayer.IDataService;

namespace DataLayer.DataService
{
    public class BookmarkMovieDataService : IBookmarkMovieDataService
    {
        public void CreateBookmarksMovie(BookmarksMovie bookmarksM)
        {
            using var db = new NorthwindContext();
            db.title_bookmarks.Add(bookmarksM);
            db.SaveChanges();
        }
        public IList<BookmarksMovie> GetBookmarksMovies()
        {
            using var db = new NorthwindContext();
            return db.title_bookmarks.ToList();
        }

        public BookmarksMovie? GetBookmarksMovie(string bookmarkMovieBID)
        {
            using var db = new NorthwindContext();
            return db.title_bookmarks.Find(bookmarkMovieBID);
        }
        public bool DeleteBookmarksMovie(string bookmarkMovieBID)
        {
            using var db = new NorthwindContext();
            var bookmarkM = db.name_bookmarks.Find(bookmarkMovieBID);
            if (bookmarkM != null)
            {
                db.name_bookmarks.Remove(bookmarkM);
            }
            else { return false; }

            return db.SaveChanges() > 0;
        }
        public bool UpdateBookmarksMovie(BookmarksMovie bookmarks)
        {
            using var db = new NorthwindContext();
            var dbBookmarksMovie = db.title_bookmarks.Find(bookmarks.bookmarkMovieBID);
            if (dbBookmarksMovie == null) return false;
            //dbBookmarksPerson.bookmarkMovieBID = bookmarks.bookmarkMovieBID; Tror ikke denne skal skiftes men den er her nu
            dbBookmarksMovie.bookmarkMovieTconst = bookmarks.bookmarkMovieTconst;
            dbBookmarksMovie.bookmarkMoviePrimarytitle = bookmarks.bookmarkMoviePrimarytitle;
            db.SaveChanges();
            return true;
        }
        /*
        public User CreateUser(string username, string password)
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
