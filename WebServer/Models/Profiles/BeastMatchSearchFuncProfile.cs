using AutoMapper;
using DataLayer.Domain;
using DataLayer.SqlFunctions;

namespace WebServer.Models.Profiles
{
    public class BeastMatchSearchFuncProfile : Profile
    {
        public BeastMatchSearchFuncProfile()
        {
            CreateMap<BestMatchSearchFunc, BestMatchSearchFuncListModel>();
            CreateMap<BestMatchSearchFuncListModel, BestMatchSearchFunc>();
        }
    }
}
