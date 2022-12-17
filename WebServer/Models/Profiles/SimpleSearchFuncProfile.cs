using AutoMapper;
using DataLayer.Domain;
using DataLayer.SqlFunctions;

namespace WebServer.Models.Profiles
{
    public class SimpleSearchFuncProfile : Profile
    {
        public SimpleSearchFuncProfile() 
        {
            CreateMap<SimpleSearchFunc, SimpleSearchFuncListModel>();
            CreateMap<SimpleSearchFuncListModel, SimpleSearchFunc>();
        }
    }
}
