using Portfolio_2.Models;
using DataLayer.Domain;
using Portfolio_2.Domain;

namespace Portfolio_2.IDataService
{
    public interface ISearchHistoryDataService
    {
        IList<SearchHistory> GetSearchHistories(int page, int pageSize);
        SearchHistory GetSearchHistories(int searchOrder);
        int GetNumberOfSearchHistories();
        void CreateSearchHistory(SearchHistory searchHistory);
        bool UpdateSearchHistory(SearchHistory searchHistoryM);
        bool DeleteSearchHistory(int searchOrder);
    }
}
