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
    public class BookmarkDataService : IBookmarkDataService
    { 
        public void CreateBookmarksPerson(Bookmarks bookmarksP)
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
        public IList<Bookmarks> GetBookmarksPers()
        {
            using var db = new NorthwindContext();
            return db.name_bookmarks.ToList();
        }
        public IList<Bookmarks> GetBookmarksMov()
        {
            using var db = new NorthwindContext();
            return db.title_bookmarks.ToList();
        }
        public Bookmarks? GetBookmarksMov(string bookmarkMovieBID)
        {
            using var db = new NorthwindContext();
            return db.name_bookmarks.Find(bookmarkMovieBID);
        }
        public Bookmarks? GetBookmarksPers(string bookmarkPersonBID)
        {
            using var db = new NorthwindContext();
            return db.name_bookmarks.Find(bookmarkPersonBID);
        }
        public bool UpdateBookmarksPerson(Bookmarks bookmarks)
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
        public void CreateBookmarksMovie(Bookmarks bookmarksM)
        {
            using var db = new NorthwindContext();
            db.title_bookmarks.Add(bookmarksM);
            db.SaveChanges();
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
        public bool UpdateBookmarksMovie(Bookmarks bookmarks)
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


    }
}
