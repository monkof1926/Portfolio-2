using AutoMapper;
using DataLayer.Domain;

namespace WebServer.Models.Profiles
{
    public class RatingHistoryProfile : Profile
    {
        public RatingHistoryProfile()
        {
            CreateMap<RatingHistory, RatingHistoryModel>();
            CreateMap<RatingHistoryModel, RatingHistory>();
        }
    }
}
