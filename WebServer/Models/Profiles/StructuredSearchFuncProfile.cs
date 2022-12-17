using AutoMapper;
using DataLayer.Domain;
using DataLayer.SqlFunctions;

namespace WebServer.Models.Profiles
{
    public class StructuredSearchFuncProfile : Profile
    {
        public StructuredSearchFuncProfile() 
        {
            CreateMap<StructuredSearchFunc, StructuredSearchFuncListModel>();
            CreateMap<StructuredSearchFuncListModel, StructuredSearchFunc>();
        }
    }
}
