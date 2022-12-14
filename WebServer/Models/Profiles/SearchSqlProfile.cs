using AutoMapper;
using DataLayer.Domain;
using DataLayer.SqlFunctions;

namespace WebServer.Models.Profiles
{
    public class SearchSqlProfile : Profile
    {
        public SearchSqlProfile() { 
            
            CreateMap<SearchFunc, SearchSqlListModel>();
            CreateMap<SearchSqlListModel, SearchFunc>();

        }
    }
}
