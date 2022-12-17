using DataLayer.Domain;
using DataLayer.IDataService;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace DataLayer.SqlFunctions
{
    public class StructuredSearchFunc : IStructuredSearchFuncDataService
    {
        public IList<SimpleQuerySearchResult> GetSearchFuncStructured(int type, string searchString)
        {
            using var ctx = new NorthwindContext();
            string[] searchwords = searchString.Split(" ");

            if (searchwords.Length > 0)
            {
                  //Type 4 is structured string search
                if (type == 4 && searchwords.Length > 3)
                {
                    return ctx.simpleQuerySearchResults.FromSqlInterpolated($"select * from structured_string_search({searchwords[0]},{searchwords[1]},{searchwords[2]},{searchwords[3]})").ToList();
                }
                else if (type == 4 && searchwords.Length == 1)
                {
                    return ctx.simpleQuerySearchResults.FromSqlInterpolated($"select * from structured_string_search({searchwords[0]},' ',' ',' ')").ToList();
                }
                else if (type == 4 && searchwords.Length == 2)
                {
                    return ctx.simpleQuerySearchResults.FromSqlInterpolated($"select * from structured_string_search({searchwords[0]},{searchwords[1]},' ',' ')").ToList();
                }
                else if (type == 4 && searchwords.Length == 3)
                {
                    return ctx.simpleQuerySearchResults.FromSqlInterpolated($"select * from structured_string_search({searchwords[0]},{searchwords[1]},{searchwords[2]},' ')").ToList();
                }
            }
            return new List<SimpleQuerySearchResult>();
        }
    }
}
