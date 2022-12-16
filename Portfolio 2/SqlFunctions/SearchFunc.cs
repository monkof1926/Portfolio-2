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

            //This is a hack we will try to improve

            if (searchwords.Length > 0)
            {
                // Type 1 is simple search
                if (type == 1)
                {
                    return ctx.QuerySearchResults.FromSqlInterpolated($"select * from simplesearcher({searchwords[0]})").ToList();
                }
                // Type 2 is specified person search called namesearch in database
                if (type == 2 && searchwords.Length > 1)
                {
                    return ctx.QuerySearchResults.FromSqlInterpolated($"select * from namesearch({searchwords[0]},{searchwords[1]})").ToList();
                } else if (type == 2 && searchwords.Length > 0)
                {
                    return ctx.QuerySearchResults.FromSqlInterpolated($"select * from namesearch({searchwords[0]},' ')").ToList();
                }
                // Type 3 is Best match search 
                if (type == 3 && searchwords.Length > 3)
                {
                    return ctx.QuerySearchResults.FromSqlInterpolated($"select * from best_match_search({searchwords[0]},{searchwords[1]},{searchwords[2]},{searchwords[3]})").ToList();
                    
                } else if (type == 3 && searchwords.Length == 1)
                {
                    return ctx.QuerySearchResults.FromSqlInterpolated($"select * from best_match_search({searchwords[0]},' ',' ',' ')").ToList();

                }
                else if (type == 3 && searchwords.Length == 2)
                {
                    return ctx.QuerySearchResults.FromSqlInterpolated($"select * from best_match_search({searchwords[0]},{searchwords[1]},' ',' ')").ToList();

                }
                else if (type == 3 && searchwords.Length == 3)
                {
                    return ctx.QuerySearchResults.FromSqlInterpolated($"select * from best_match_search({searchwords[0]},{searchwords[1]},{searchwords[2]},' ')").ToList();

                }
                //Type 4 is structured string search
                else if (type == 4 && searchwords.Length > 3)
                {
                    return ctx.QuerySearchResults.FromSqlInterpolated($"select * from structured_string_search({searchwords[0]},{searchwords[1]},{searchwords[2]},{searchwords[3]})"). ToList();
                }
                else if (type == 4 && searchwords.Length == 1)
                {
                    return ctx.QuerySearchResults.FromSqlInterpolated($"select * from structured_string_search({searchwords[0]},' ',' ',' ')").ToList();
                }
                else if (type == 4 && searchwords.Length == 2)
                {
                    return ctx.QuerySearchResults.FromSqlInterpolated($"select * from structured_string_search({searchwords[0]},{searchwords[1]},' ',' ')").ToList();
                }
                else if (type == 4 && searchwords.Length == 3)
                {
                    return ctx.QuerySearchResults.FromSqlInterpolated($"select * from structured_string_search({searchwords[0]},{searchwords[1]},{searchwords[2]},' ')").ToList();
                }
                //type 5 is exact match search
                else if (type == 5 && searchwords.Length > 3)
                {
                    return ctx.QuerySearchResults.FromSqlInterpolated($"select * from exact_match_search({searchwords[0]},{searchwords[1]},{searchwords[2]},{searchwords[3]})").ToList();
                }
                else if (type == 5 && searchwords.Length == 1)
                {
                    return ctx.QuerySearchResults.FromSqlInterpolated($"select * from exact_match_search({searchwords[0]},' ',' ',' ')").ToList();
                }
                else if (type == 5 && searchwords.Length == 2)
                {
                    return ctx.QuerySearchResults.FromSqlInterpolated($"select * from exact_match_search({searchwords[0]},{searchwords[1]},' ',' ')").ToList();
                }
                else if (type == 5 && searchwords.Length == 3)
                {
                    return ctx.QuerySearchResults.FromSqlInterpolated($"select * from exact_match_search({searchwords[0]},{searchwords[1]},{searchwords[2]},' ')").ToList();
                }
            }

            return new List<QuerySearchResult>();
        }


    }
}