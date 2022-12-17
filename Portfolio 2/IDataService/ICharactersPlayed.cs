using DataLayer.Domain;

namespace DataLayer.IDataService
{
    public interface ICharactersPlayed
    {
        CharatersPlayed GetCharacters(string nconst);
    }
}
