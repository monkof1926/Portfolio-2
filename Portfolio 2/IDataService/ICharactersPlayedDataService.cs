using DataLayer.Domain;

namespace DataLayer.IDataService
{
    public interface ICharactersPlayedDataService
    {
        CharatersPlayed? GetCharacters(string nconst);
    }
}
