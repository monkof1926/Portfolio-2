using DataLayer;
using DataLayer.IDataService;
using DataLayer.Domain;

namespace DataLayer.DataService
{
    public class CharactersPlayedDataService : ICharactersPlayedDataService 
    {
        public CharactersPlayed? GetCharacters(string? cpnconst)
        {
            using var db = new NorthwindContext();
            if (cpnconst != null)
            {
                return db.characters_played.Find(cpnconst);
            }
                return null;

        }
    }
}
