using DataLayer.Domain;


namespace DataLayer.IDataService
{
    public interface IBookmarkPersonDataService
    {
        IList<BookmarksPerson> GetBookmarksPersons();
        BookmarksPerson? GetBookmarksPerson(string bookmarkPersonBID);
        void CreateBookmarksPerson(BookmarksPerson bookmarksP);
        bool UpdateBookmarksPerson(BookmarksPerson bookmarksP);
        bool DeleteBookmarksPerson(string bookmarkPersonBID);
       
       // User CreateUser(string username, string password = null);
    }
}
