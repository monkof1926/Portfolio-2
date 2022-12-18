using DataLayer.Domain;

namespace DataLayer.IDataService
{
    public interface ICharactersPlayedDataService
    {
        CharactersPlayed? GetCharacters(string? cpnconst);
    }
}
