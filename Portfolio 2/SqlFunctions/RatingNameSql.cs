using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.SqlFunctions
{
    public class RatingNameSql
    {
        static void UseEntityFrameworkToCallFunction(string connectionString)
        {
            Console.WriteLine("Call function from Entity Framework");
            using var ctx = new NorthwindContex(connectionString);

            int id = 101;
            string name = "testing";
            string description = "testing desc";

            ctx.Database.ExecuteSqlInterpolated($"select insertcategory({id},{name},{description})");

            var category = ctx.Categories.Find(id);

            Console.WriteLine("Newly inserted category:");
            Console.WriteLine($"Id={category.Id}, Name={category.Name}, Description={category.Description}");

            ctx.Categories.Remove(category);

            ctx.SaveChanges();
        }
    }
}
