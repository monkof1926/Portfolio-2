using DataLayer;
using DataLayer.IDataService;
using DataLayer.Domain;
using System.Runtime.CompilerServices;

namespace DataLayer.DataService
{
    public class CharactersPlayedDataService : ICharactersPlayedDataService
    {
        public CharatersPlayed? GetCharacters(string? nconst)    
        {
            using var db = new NorthwindContext();
            if (nconst == null)
            {
                return null;
            }
            else
            {
                return db.characters_played.Find(nconst);
            }
        }
    }
}
