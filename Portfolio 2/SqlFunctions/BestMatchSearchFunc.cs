using DataLayer.IDataService;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.SqlFunctions
{
    public class BestMatchSearchFunc : IBestMatchSearchFuncDatService
    {
        public IList<RankQuerySearchResult> GetSearchFuncBest(int type, string searchString)
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
                else if (type == 3 && searchwords.Length == 1)
                {
                    return ctx.rankQuerySearchResults.FromSqlInterpolated($"select * from best_match_search({searchwords[0]},' ',' ',' ')").ToList();

                }
                else if (type == 3 && searchwords.Length == 2)
                {
                    return ctx.rankQuerySearchResults.FromSqlInterpolated($"select * from best_match_search({searchwords[0]},{searchwords[1]},' ',' ')").ToList();

                }
                else if (type == 3 && searchwords.Length == 3)
                {
                    return ctx.rankQuerySearchResults.FromSqlInterpolated($"select * from best_match_search({searchwords[0]},{searchwords[1]},{searchwords[2]},' ')").ToList();

                }
            }
            return new List<RankQuerySearchResult>();
        }
    }
}
