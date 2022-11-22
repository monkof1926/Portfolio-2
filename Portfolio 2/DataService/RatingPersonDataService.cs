using DataLayer.Domain;
using DataLayer.IDataService;


namespace DataLayer.DataService
{
    public class RatingPersonDataService : IRatingPersonDataService
    {
        public void CreateRatingPerson(RatingPerson rating)
        {
            using var db = new NorthwindContext();
            db.name_ratings.Add(rating);
            db.SaveChanges();
        }
        public bool DeleteRatingPerson(string ratingnconst)
        {
            using var db = new NorthwindContext();
            var ratingP = db.name_ratings.Find(ratingnconst);
            if (ratingP != null)
            {
                db.name_ratings.Remove(ratingP);
            }
            else { return false; }

            return db.SaveChanges() > 0;
        }
        public IList<RatingPerson> GetRatingsPersons()
        {
            using var db = new NorthwindContext();
            return db.name_ratings.ToList();
        }
        public RatingPerson? GetRatingsPerson(string ratingAvergePerson)
        {
            using var db = new NorthwindContext();
            return db.name_ratings.Find(ratingAvergePerson);
            
        }
        public bool UpdateRatingPerson(RatingPerson rating) 
        {
            using var db = new NorthwindContext();
            var dbRatingPerson = db.name_ratings.Find(rating.ratingnconst);
            if (dbRatingPerson == null) return false;
            dbRatingPerson.ratingAvergePerson = rating.ratingAvergePerson;
            dbRatingPerson.ratingNumPerson = rating.ratingNumPerson;
            db.SaveChanges();
            return true;
        }
       /* public User CreateUser(string username, string password)
        {
            var user = new User
            {
                username = username,
                password = password,
            };
            return user;
        }*/
    }
}
