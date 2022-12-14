using Microsoft.EntityFrameworkCore;

namespace DataLayer.SqlFunctions
{
    public class SearchFunc
    {
        static void UseEntityFramework(
            string connectionstring,
            int type,
            string searchString
            )


        {
            Console.WriteLine("Entity framework");
            using var ctx = new NorthwindContext();
            string[] searchwords = searchString.Split("");

            switch (type)
            {
                case 1:
                    var result1 = ctx.simplesearcher.FromSqlInterpolated($"select * from simplesearcher({searchwords[0]})");
                    foreach (var searchresult in result1)
                    {
                        Console.WriteLine($"{searchresult.tconst}, {searchresult.title}");
                    }
                    break;
                case 2:
                    var result2 = ctx.name_search.FromSqlInterpolated($"select * from namesearch({searchwords[0]},{searchwords[1]})");
                    foreach (var searchresult in result2)
                    {
                        Console.WriteLine($"{searchresult.pname}, {searchresult.nconst}");
                    }
                    break;
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
                    Console.WriteLine("Something went wrong try again");
                    break;
            }
        }
    }
}