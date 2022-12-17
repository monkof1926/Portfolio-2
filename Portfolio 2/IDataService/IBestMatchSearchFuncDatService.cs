using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.IDataService
{
    public interface IBestMatchSearchFuncDatService
    {
        IList<RankQuerySearchResult> GetSearchFuncBest(int? type, string? searchString , int page, int pageSize);

        int GetNumberOfSearch();
    }
}
    