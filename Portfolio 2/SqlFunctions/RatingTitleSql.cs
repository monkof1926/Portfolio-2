using Microsoft.EntityFrameworkCore;

namespace DataLayer.SqlFunctions
{
    public class RatingTitleSql
    {
        static void UseEntityFrameworkToCallFunction(
            //string connectionString,
            string rtconst,
            float rating,
            string ruserid)
        {
            Console.WriteLine("Call function from Entity Framework");
            using var ctx = new NorthwindContext();

            ctx.Database.ExecuteSqlInterpolated($"select rate_title({rtconst},{rating},{ruserid})");
            //ctx.Database.ExecuteSqlInterpolated($"select insertcategory({id},{name},{description})");

            var ratetitle = ctx.rate_title.Find(rtconst);
            //var category = ctx.Categories.Find(id);

            Console.WriteLine("Newly inserted Rating:");
            Console.WriteLine($"rnconst={ratetitle.tconst}, Rating={ratetitle.rating}, UserID={ratetitle.userID}");
            //Console.WriteLine($"Id={category.Id}, Name={category.Name}, Description={category.Description}");

            ctx.rate_title.Remove(ratetitle);
            //ctx.Categories.Remove(category);

            ctx.SaveChanges();
        }
    }
}
