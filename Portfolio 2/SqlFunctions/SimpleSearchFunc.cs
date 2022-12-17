using DataLayer.Domain;
using DataLayer.IDataService;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace DataLayer.SqlFunctions
{
    public class SimpleSearchFunc : ISimpleSearchFuncDataService
    {
        public IList<SimpleQuerySearchResult> GetSearchFuncSimple(int type, string searchString)
        {
            using var ctx = new NorthwindContext();
            string[] searchwords = searchString.Split(" ");

            if (searchwords.Length > 0)
            {
                // Type 1 is simple search
                if (type == 1)
                {
                    return ctx.simpleQuerySearchResults.FromSqlInterpolated($"select * from simplesearcher({searchwords[0]})").ToList();
                }
            }
            return new List<SimpleQuerySearchResult>();
        }
    }
}

