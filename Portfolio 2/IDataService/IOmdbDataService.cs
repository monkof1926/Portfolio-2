using DataLayer.Domain;

namespace DataLayer.IDataService
{
    public interface IOmdbDataService
    {
        Omdb? GetOmdb(string omdbID);

    }
}
