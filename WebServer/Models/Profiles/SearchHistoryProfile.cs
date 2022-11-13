using AutoMapper;
using DataLayer.Domain;

namespace WebServer.Models.Profiles
{
    public class SearchHistoryProfile : Profile
    {
        public SearchHistoryProfile()
        {
            CreateMap<SearchHistory, SearchHistoryModel>();
            CreateMap<SearchHistoryModel, SearchHistory>();
        }
    }
}
