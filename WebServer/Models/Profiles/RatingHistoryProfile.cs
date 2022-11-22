using AutoMapper;
using DataLayer.Domain;

namespace WebServer.Models.Profiles
{
    public class RatingHistoryProfile : Profile
    {
        public RatingHistoryProfile()
        {
            CreateMap<RatingHistoryPerson, RatingHistoryModel>();
            CreateMap<RatingHistoryModel, RatingHistoryPerson>();
        }
    }
}
