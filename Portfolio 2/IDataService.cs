using DataLayer.Domain;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio_2
{
    internal interface IDataService
    {
        IList<User>GetUser();
        

    }
}
