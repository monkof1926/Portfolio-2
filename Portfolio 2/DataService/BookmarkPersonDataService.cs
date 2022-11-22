using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Domain;
using DataLayer.IDataService;
using DataLayer;
using System.Data.Common;

namespace DataLayer.DataService
{
    public class BookmarkPersonDataService : IBookmarkPersonDataService
    { 
        public void CreateBookmarksPerson(BookmarksPerson bookmarksP)
        {
            using var db = new NorthwindContext();
            db.name_bookmarks.Add(bookmarksP);
            db.SaveChanges();
        }
        public bool DeleteBookmarksPerson(string bookmarkPersonBID)
        {
            using var db = new NorthwindContext();
            var bookmarkP = db.name_bookmarks.Find(bookmarkPersonBID);
            if (bookmarkP != null)
            {
                db.name_bookmarks.Remove(bookmarkP);
            } else { return false; }
            
            return db.SaveChanges() > 0;
        }
        public IList<BookmarksPerson> GetBookmarksPersons()
        {
            using var db = new NorthwindContext();
            return db.name_bookmarks.ToList();
        }
        public BookmarksPerson? GetBookmarksPerson(string bookmarkPersonBID)
        {
            using var db = new NorthwindContext();
            return db.name_bookmarks.Find(bookmarkPersonBID);
        }
        public bool UpdateBookmarksPerson(BookmarksPerson bookmarks)
        {
            using var db = new NorthwindContext();
            var dbBookmarksPerson = db.name_bookmarks.Find(bookmarks.bookmarkPersonBID);
            if (dbBookmarksPerson == null) return false;
            //dbBookmarksPerson.bookmarkPersonBID = bookmarks.bookmarkPersonBID; Tror ikke denne skal skiftes men den er her nu
            dbBookmarksPerson.bookmarkPersonNconst = bookmarks.bookmarkPersonNconst;
            dbBookmarksPerson.bookmarkPersonName = bookmarks.bookmarkPersonName;
            db.SaveChanges();
            return true;
        }
       
        public User CreateUser(string username, string password)
        {
            var user = new User
            {
                username = username,
                password = password,
            };
            return user;
        }


    }
}
