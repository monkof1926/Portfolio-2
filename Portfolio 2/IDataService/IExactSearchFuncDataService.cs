using DataLayer.Models;


namespace DataLayer.IDataService
{
    public interface IExactSearchFuncDataService
    {
        IList<RankQuerySearchResult> GetSearchFuncExact(int type, string searchString);
    }
}
