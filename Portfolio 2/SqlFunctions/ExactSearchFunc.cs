using DataLayer.Domain;
using DataLayer.IDataService;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace DataLayer.SqlFunctions
{
    public class ExactSearchFunc : IExactSearchFuncDataService
    {
        public IList<RankQuerySearchResult> GetSearchFuncExact(int type, string searchString)
        {
            using var ctx = new NorthwindContext();
            string[] searchwords = searchString.Split(" ");

            if (searchwords.Length > 0)
            {
                //type 5 is exact match search
                if (type == 5 && searchwords.Length > 3)
                {
                    return ctx.rankQuerySearchResults.FromSqlInterpolated($"select * from exact_match_search({searchwords[0]},{searchwords[1]},{searchwords[2]},{searchwords[3]})").ToList();
                }

            }
            return new List<RankQuerySearchResult>();
        }
    }
}
