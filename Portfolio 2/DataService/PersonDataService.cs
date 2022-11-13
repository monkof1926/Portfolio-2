using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Domain;
using DataLayer.Models;
using DataLayer.IDataService;
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
            return db.name_basics
                .Include(x => x.fullName)
                .Skip(page * pageSize)
                .Take(pageSize)
                .OrderBy(x => x.nameID)
                .ToList();
        }
        public Person? GetPersons(string nameID)
        {
            using var db = new NorthwindContext();
            if (nameID != null)
            {
                return db.name_basics.Find(nameID);
            }
        }
        public bool UpdatePerson(Person person)
        {
            using var db = new NorthwindContext();
            var dbPerson = db.name_basics.Find(person.personID);
            if (dbPerson == null) return false;
            dbPerson.personID = person.personID;
            dbPerson.fullName = person.fullName;
            db.SaveChanges();
            return true;
        }
        public int GetNumberOfPerons()
        {
            using var db = new NorthwindContext();
            return db.name_basics.Count();
        }
        public IList<PersonSearchModel> GetPersonSearches(string searchPerson)
        {
            using var db = new NorthwindContext();
            return db.name_basics
                .Include(x => x.fullName)
                .Where(x => x.fullName == search)
                .Select(x => new PersonSearchModel
                {
                    PersonTitle = x.fullName,
                    PersonName = x.Person.fullName
                })
                .ToList();
        }
    }
}
