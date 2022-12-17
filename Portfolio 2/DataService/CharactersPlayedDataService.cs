using DataLayer;
using DataLayer.IDataService;
using DataLayer.Domain;

namespace DataLayer.DataService
{
    public class CharactersPlayedDataService : ICharactersPlayedDataService 
    {
        public CharatersPlayed? GetCharacters(string? nconst)
        {
            using var db = new NorthwindContext();
            if (nconst != null)
            {
                return db.Characters_played.Find(nconst);
            }

            else return null;

        }
    }
}
