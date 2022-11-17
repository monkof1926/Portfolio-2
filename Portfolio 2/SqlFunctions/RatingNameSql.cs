using Microsoft.EntityFrameworkCore;

namespace DataLayer.SqlFunctions
{
    public class RatingNameSql
    {
        static void UseEntityFrameworkToCallFunction(
            //string connectionString,
            string rnconst,
            float rating,
            string ruserid)
        {
            Console.WriteLine("Call function from Entity Framework");
            using var ctx = new NorthwindContext();

            ctx.Database.ExecuteSqlInterpolated($"select rate_name({rnconst},{rating},{ruserid})");
            //ctx.Database.ExecuteSqlInterpolated($"select insertcategory({id},{name},{description})");

            var ratename = ctx.rate_name.Find(rnconst);
            //var category = ctx.Categories.Find(id);

            Console.WriteLine("Newly inserted Rating:");
            Console.WriteLine($"rnconst={ratename.nconst}, Rating={ratename.rating}, UserID={ratename.userID}");
            //Console.WriteLine($"Id={category.Id}, Name={category.Name}, Description={category.Description}");

            ctx.rate_name.Remove(ratename);
            //ctx.Categories.Remove(category);

            ctx.SaveChanges();
        }
    }
}
