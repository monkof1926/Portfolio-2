using DataLayer;
using DataLayer.Domain;
using DataLayer.IDataService;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;



namespace DataLayer.DataService
{
    public class PersonDataService : IPersonDataService
    {
        public void CreatePerson(Person person)
        {
            using var db = new NorthwindContext();
            db.name_basics.Add(person);
            db.SaveChanges();
        }
        public bool DeletePerson(string personID)
        {
            using var db = new NorthwindContext();
            var person = db.name_basics.Find(personID);
            if (person != null)
            {
                db.name_basics.Remove(person);
            }
            else { return false; }

            return db.SaveChanges() > 0;
        }
        public IList<Person> GetPersons(int page, int pageSize)
        {
            using var db = new NorthwindContext();
            var charaters = db.name_basics
                .Skip(page * pageSize)
                .Take(pageSize)
                .OrderBy(x => x.nameID)
                .ToList();
            /* this hack did'nt work in the time frame 
            var charatersPlayedinMovie = new CharactersPlayedDataService();

            foreach (var c in charaters)
            {
                c.characters_played = charatersPlayedinMovie.GetCharacters(c.nameID);
            }
            */
            return charaters;
        }
        public Person? GetPerson(string? nameID)
        {
            using var db = new NorthwindContext();
            if (nameID != null)
            {
                return db.name_basics.Find(nameID);
            }
            return null;
        }
        public bool UpdatePerson(Person person)
        {
            using var db = new NorthwindContext();
            var dbPerson = db.name_basics.Find(person.nameID);
            if (dbPerson == null) return false;
            dbPerson.nameID = person.nameID;
            dbPerson.fullName = person.fullName;
            db.SaveChanges();
            return true;
        }
        public int GetNumberOfPersons()
        {
            using var db = new NorthwindContext();
            return db.name_basics.Count();
        }
        public IList<PersonSearchModel> GetPersonSearches(string searchPerson)
        {
            using var db = new NorthwindContext();
            return db.name_basics
                .Include(x => x.fullName)
                .Where(x => x.fullName == searchPerson)
                .Select(x => new PersonSearchModel
                {
                    PersonFullName = x.fullName
                })
                .ToList();
        }
    }
}
