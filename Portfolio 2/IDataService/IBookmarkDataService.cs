using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Portfolio_2.Models;
using DataLayer.Domain;


namespace DataLayer.IDataService
{
    public interface IBookmarkDataService
    {
        IList<Bookmarks> GetBookmarks();
        Bookmarks? GetBookmarks(string bookmarkPersonBID, string bookmarkMovieBID);
        void CreateBookmarksPerson(Bookmarks bookmarksP);
        bool UpdateBookmarksPerson(Bookmarks bookmarksP);
        bool DeleteBookmarksPerson(string bookmarkPersonBID);
        void CreateBookmarksMovie(Bookmarks bookmarksM);
        bool UpdateBookmarksMovie(Bookmarks bookmarksM);
        bool DeleteBookmarksMovie(string bookmarkMovieBID);
    }
}
