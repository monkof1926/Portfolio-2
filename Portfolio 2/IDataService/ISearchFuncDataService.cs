using DataLayer.Domain;
using DataLayer.SqlFunctions;

namespace Portfolio_2.IDataService
{
    public interface ISearchFuncDataService
    {
        SearchFunc GetSearchFunc(string connectionstring, int type, string searchString);
    }
}
