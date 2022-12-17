using DataLayer.Domain;
using DataLayer.Models;

namespace DataLayer.IDataService
{
    public interface INameSearchFuncDataService
    {
        IList<QuerySearchResult> GetSearchFunc(int type, string searchString);
       
       
    
    }
}
