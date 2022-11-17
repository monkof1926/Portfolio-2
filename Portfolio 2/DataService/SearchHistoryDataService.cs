using DataLayer.Domain;
using DataLayer.IDataService;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.DataService
{
    public class SearchHistoryDataService : ISearchHistoryDataService
    {
        public void CreateSearchHistory(SearchHistory searchHistory)
        {
            using var db = new NorthwindContext();
            db.searchhistory.Add(searchHistory);
            db.SaveChanges();
        }
        public bool DeleteSearchHistory(int? searchOrder)
        {
            using var db = new NorthwindContext();
            var search = db.searchhistory.Find(searchOrder);
            if (search != null)
            {
                db.searchhistory.Remove(search);
            }
            else { return false; }

            return db.SaveChanges() > 0;
        }
        public IList<SearchHistory> GetSearchHistories(int page, int pageSize)

        {
            using var db = new NorthwindContext();
            return db.searchhistory
                .Include(x => x.searchWord)
                .Skip(page * pageSize)
                .Take(pageSize)
                .OrderBy(x => x.searchOrder)
                .ToList();
        }
        public SearchHistory? GetSearchHistories(int searchOrder)
        {
            using var db = new NorthwindContext();
            return db.searchhistory.Find(searchOrder);
        }
        public bool UpdateSearchHistory(SearchHistory searchHistoryM)
        {
            using var db = new NorthwindContext();
            var dbSearch = db.searchhistory.Find(searchHistoryM.searchOrder);
            if (dbSearch == null) return false;
            dbSearch.searchOrder = searchHistoryM.searchOrder;
            dbSearch.searchWord = searchHistoryM.searchWord;
            db.SaveChanges();
            return true;
        }
        public int GetNumberOfSearchHistories()
        {
            using var db = new NorthwindContext();
            return db.searchhistory.Count();
        }
        public IList<SearchHistorySearchModel> GetSearchHistoryByUser(string search)
        {
            using var db = new NorthwindContext();
            return db.searchhistory
                .Include(x => x.searchWord)
                .Where(x => x.searchWord == search)
                .Select(x => new SearchHistorySearchModel
                {
                    searchSearch = x.searchWord
                })
                .ToList();
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
