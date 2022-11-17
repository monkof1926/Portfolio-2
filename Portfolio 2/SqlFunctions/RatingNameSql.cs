using Microsoft.EntityFrameworkCore;

namespace DataLayer.SqlFunctions
{
    public class RatingNameSql
    {
        static void UseEntityFrameworkToCallFunction(
            string rnconst,
            float rating,
            string ruserid)
        {
            Console.WriteLine("Call function from Entity Framework");
            using var ctx = new NorthwindContext();

            ctx.Database.ExecuteSqlInterpolated($"select rate_name({rnconst},{rating},{ruserid})");

            var ratename = ctx.rate_name.Find(rnconst);

            Console.WriteLine("Newly inserted Rating:");
            Console.WriteLine($"rnconst={ratename.nconst}, Rating={ratename.rating}, UserID={ratename.userID}");

            ctx.rate_name.Remove(ratename);

            ctx.SaveChanges();
        }
    }
}
