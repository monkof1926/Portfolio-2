using AutoMapper;
using Portfolio_2.Domain;

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
