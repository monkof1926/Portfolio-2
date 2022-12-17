using AutoMapper;
using DataLayer.Domain;
using DataLayer.SqlFunctions;

namespace WebServer.Models.Profiles
{
    public class NameSearchFuncProfile : Profile
    {
        public NameSearchFuncProfile() { 
            
            CreateMap<NameSearchFunc, NameSearchFuncListModel>();
            CreateMap<NameSearchFuncListModel, NameSearchFunc>();

        }
    }
}
