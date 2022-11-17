using DataLayer.Domain;


namespace DataLayer.IDataService
{
    public interface IBookmarkDataService
    {
        IList<Bookmarks> GetBookmarksMov();
        IList<Bookmarks> GetBookmarksPers();

        Bookmarks? GetBookmarksMov(string bookmarkMovieBID);
        Bookmarks? GetBookmarksPers(string bookmarkPersonBID);

        void CreateBookmarksPerson(Bookmarks bookmarksP);
        bool UpdateBookmarksPerson(Bookmarks bookmarksP);
        bool DeleteBookmarksPerson(string bookmarkPersonBID);
        void CreateBookmarksMovie(Bookmarks bookmarksM);
        bool UpdateBookmarksMovie(Bookmarks bookmarksM);
        bool DeleteBookmarksMovie(string bookmarkMovieBID);
        User CreateUser(string username, string password = null);
    }
}
