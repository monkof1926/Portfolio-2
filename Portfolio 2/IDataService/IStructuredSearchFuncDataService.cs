using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.IDataService
{
    public interface IStructuredSearchFuncDataService
    {
        IList<SimpleQuerySearchResult> GetSearchFuncStructured(int type, string searchString);
    }
}
