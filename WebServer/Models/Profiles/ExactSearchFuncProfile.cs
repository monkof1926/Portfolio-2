using AutoMapper;
using DataLayer.Domain;
using DataLayer.SqlFunctions;

namespace WebServer.Models.Profiles
{
    public class ExactSearchFuncProfile : Profile
    {
        public ExactSearchFuncProfile() 
        { 
            CreateMap<ExactSearchFunc, ExactSearchFuncListModel>();
            CreateMap<ExactSearchFuncListModel, ExactSearchFunc>();
        }
    }
}
