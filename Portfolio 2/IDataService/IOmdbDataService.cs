using DataLayer.Domain;

namespace DataLayer.IDataService
{
    public interface IOmdbDataService
    {
       // IList<Omdb> GetOmdbs(string omdbID);
        Omdb? GetOmdb(string omdbID);

    }
}
