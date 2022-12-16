using DataLayer;
using Microsoft.EntityFrameworkCore;


namespace DataLayer.SqlFunctions
{
    public class RatingTitleSql
    {
        static void UseEntityFrameworkToCallFunction(
            string rtconst,
            float rating,
            string ruserid)
        {
            Console.WriteLine("Call function from Entity Framework");
            using var ctx = new NorthwindContext();

            ctx.Database.ExecuteSqlInterpolated($"select rate_title({rtconst},{rating},{ruserid})");

            var ratetitle = ctx.rate_title.Find(rtconst);

            Console.WriteLine("Newly inserted Rating:");
            Console.WriteLine($"rnconst={ratetitle.tconst}, Rating={ratetitle.rating}, UserID={ratetitle.userID}");

            ctx.rate_title.Remove(ratetitle);

            ctx.SaveChanges();
        }
    }
}
