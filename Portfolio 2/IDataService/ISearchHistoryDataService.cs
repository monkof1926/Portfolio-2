using DataLayer.Domain;
using DataLayer.Models;


namespace DataLayer.IDataService
{
    public interface ISearchHistoryDataService
    {
        IList<SearchHistory> GetSearchHistories(int page, int pageSize);
        SearchHistory GetSearchHistories(int? searchOrder);
        int GetNumberOfSearchHistories();
        void CreateSearchHistory(SearchHistory searchHistory);
        bool UpdateSearchHistory(SearchHistory searchHistoryM);
        bool DeleteSearchHistory(int? searchOrder);
        //int GetNumberSearchHistory();
        IList<SearchHistorySearchModel> GetSearchHistoryByUser(string search);
    }
}
