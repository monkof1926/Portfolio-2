using DataLayer.Models;
using DataLayer.Domain;

namespace DataLayer.IDataService
{
    public interface IPersonDataService
    {

        IList<Person> GetPersons(int page, int pageSize);
        Person? GetPersons(string nameID);
        void CreatePerson(Person person);
        bool UpdatePerson(Person person);
        bool DeletePerson(string personID);
        int GetNumberOfPersons();
        //IList<PersonSearchModel> GetPersonSearches(string searchPerson);
    }
}
