using DataLayer.Domain;
using DataLayer.IDataService;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;


namespace DataLayer.SqlFunctions
{
    
    public class NameSearchFunc : INameSearchFuncDataService
    {
        public IList<QuerySearchResult> GetSearchFunc(int type, string searchString)
        {
            using var ctx = new NorthwindContext();
            string[] searchwords = searchString.Split(" ");

            //This is a hack we will try to improve

            if (searchwords.Length > 0 && type == 2)
            {

                // Type 2 is specified person search called namesearch in database
                if (type == 2 && searchwords.Length > 1)
                {
                    return ctx.QuerySearchResults.FromSqlInterpolated($"select * from namesearch({searchwords[0]},{searchwords[1]})").ToList();
                }
                else if (type == 2 && searchwords.Length > 0)
                {
                    return ctx.QuerySearchResults.FromSqlInterpolated($"select * from namesearch({searchwords[0]},' ')").ToList();
                }

            }

            return new List<QuerySearchResult>();
        }
       

    }
}
