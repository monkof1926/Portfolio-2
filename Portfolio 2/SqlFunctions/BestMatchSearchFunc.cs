using DataLayer.IDataService;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.SqlFunctions
{
    public class BestMatchSearchFunc : IBestMatchSearchFuncDatService
    {   
        // This is a hack and if there is more time it will be work at 
        public IList<RankQuerySearchResult> GetSearchFuncBest(int? type, string? searchString /*, int page, int pageSize*/)
        {
            using var ctx = new NorthwindContext();
            string[] searchwords = searchString.Split(" ");

            if (searchwords.Length > 0)
            {
                // Type 3 is Best match search 
                if (type == 3 && searchwords.Length > 3)
                {
                    return ctx.rankQuerySearchResults.FromSqlInterpolated($"select * from best_match_search({searchwords[0]},{searchwords[1]},{searchwords[2]},{searchwords[3]})").ToList();

                }
                if (type == 3 && searchwords.Length == 1)
                {
                    
                    return ctx.rankQuerySearchResults.FromSqlInterpolated($"select * from best_match_search({searchwords[0]},' ',' ',' ')").ToList();

                }
                 if (type == 3 && searchwords.Length == 2)
                {
                    return ctx.rankQuerySearchResults.FromSqlInterpolated($"select * from best_match_search({searchwords[0]},{searchwords[1]},' ',' ')").ToList();

                }
                 if (type == 3 && searchwords.Length == 3)
                {
                    return ctx.rankQuerySearchResults.FromSqlInterpolated($"select * from best_match_search({searchwords[0]},{searchwords[1]},{searchwords[2]},' ')").ToList();

                }
            }
            return new List<RankQuerySearchResult>();


        }
      /*  public int GetNumberOfSearch()
        {
            using var ctx = new NorthwindContext();
            return ctx.bestMatchQuerySearchResults.Count();
        }*/
    }
}
