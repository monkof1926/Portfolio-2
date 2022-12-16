using DataLayer.Domain;
using DataLayer.Models;
using DataLayer.SqlFunctions;

namespace DataLayer.IDataService
{
    public interface ISearchFuncDataService
    {
        IList<QuerySearchResult> GetSearchFunc(int type, string searchString);
    }
}
