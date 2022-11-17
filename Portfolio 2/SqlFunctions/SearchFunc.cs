using DataLayer;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Npgsql;


namespace Portfolio_2.SqlFunctions
{
    internal class SearchFunc 
    {
        //simplesearch 1 varchar case 1
        //namesearch 2 varchar case 2
        //bmsearch 4 varchar case 3
        //structuredStringsearch 4 varchar case 4
        static void UseEntityFramework(
            string connectionstring,
            int type,
            string searchword1,
            string searchword2,
            string searchword3,
            string searchword4) 
        {
            Console.WriteLine("Entity framework");
            using var ctx = new NorthwindContext();

            switch (type) 
            {
                case 1:
                    var result1 = ctx.Searchresults.FromSqlInterpolated($"select * from simplesearcher({searchword1})");
                    foreach (var searchresult in result1) 
                    {
                        Console.WriteLine($"{searchresult.something}, {searchresult.somethingelse}");
                    }
                    break;
                case 2:
                    var result2 = ctx.Searchresults.FromSqlInterpolated($"select * from namesearch({searchword1},{searchword2})");
                    foreach (var searchresult in result2)
                    {
                        Console.WriteLine($"{searchresult.something}, {searchresult.somethingelse}");
                    }
                    break;
                case 3:
                    var result3 = ctx.Searchresults.FromSqlInterpolated($"select * from best_match_search({searchword1},{searchword2},{searchword3},{searchword4})");
                    foreach (var searchresult in result3)
                    {
                        Console.WriteLine($"{searchresult.something}, {searchresult.somethingelse}");
                    }
                    break;
                case 4:
                    var result4 = ctx.Searchresults.FromSqlInterpolated($"select * from structured_string_search({searchword1},{searchword2},{searchword3},{searchword4})");
                    foreach (var searchresult in result4)
                    {
                        Console.WriteLine($"{searchresult.something}, {searchresult.somethingelse}");
                    }
                    break;
                default:
                    Console.WriteLine("Something went wrong try again");
                    break;
            }
        }
    }
}
