using DataLayer.Domain;
using DataLayer.IDataService;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;


namespace DataLayer.SqlFunctions
{
    //"pname" varchar, "t_const" varchar, "n_const" bpchar
    public class SearchFunc : ISearchFuncDataService
    {
        public IList<QuerySearchResult> GetSearchFunc(int type, string searchString)
        {
            using var ctx = new NorthwindContext();
            string[] searchwords = searchString.Split(" ");

            if (searchwords.Length > 0)
            {
                if (type == 1)
                {
                    return ctx.QuerySearchResults.FromSqlInterpolated($"select * from simplesearcher({searchwords[0]})").ToList();
                }
                if (type == 2 && searchwords.Length > 1)
                {
                    return ctx.QuerySearchResults.FromSqlInterpolated($"select * from namesearch({searchwords[0]},{searchwords[1]})").ToList();
                }
                /*switch (type)
                {
                    case 1:
                        return ctx.SearchResults.FromSqlInterpolated($"select * from simplesearcher({searchwords[0]})").ToList();
                    case 2:

                        return ctx.SearchResults.FromSqlInterpolated($"select * from namesearch({searchwords[0]},{searchwords[1]})").ToList();
                        
                           case 3:
                               var result3 = ctx.best_match_search.FromSqlInterpolated($"select * from best_match_search({searchwords[0]},{searchwords[1]},{searchwords[2]},{searchwords[3]})");
                               foreach (var searchresult in result3)
                               {
                                   Console.WriteLine($"{searchresult.rank}, {searchresult.tconst}, {searchresult.title}");
                               }
                               break;
                           case 4:
                               var result4 = ctx.structured_string_search.FromSqlInterpolated($"select * from structured_string_search({searchwords[0]},{searchwords[1]},{searchwords[2]},{searchwords[3]})");
                               foreach (var searchresult in result4)
                               {
                                   Console.WriteLine($"{searchresult.tconst}, {searchresult.title}");
                               }
                               break;
                           case 5:
                               var result5 = ctx.structured_string_search.FromSqlInterpolated($"select * from exact_match_search({searchwords[0]},{searchwords[1]},{searchwords[2]},{searchwords[3]})");
                               foreach (var searchresult in result5)
                               {
                                   Console.WriteLine($"{searchresult.tconst}, {searchresult.title}, {searchresult.rank}");
                               }
                               break;
                           default:
                               Console.W
                           riteLine("Something went wrong try again");
                               break;
                        
                }*/
            }

            return new List<QuerySearchResult>();
        }


    }
}