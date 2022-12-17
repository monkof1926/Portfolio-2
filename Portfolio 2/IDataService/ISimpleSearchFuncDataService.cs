using DataLayer.Models;

namespace DataLayer.IDataService
{
    public interface ISimpleSearchFuncDataService
    {
        IList<SimpleQuerySearchResult> GetSearchFuncSimple(int type, string searchString);
    }
}
