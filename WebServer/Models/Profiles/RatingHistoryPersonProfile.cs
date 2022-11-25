using AutoMapper;
using DataLayer.Domain;

namespace WebServer.Models.Profiles
{
    public class RatingHistoryPersonProfile : Profile
    {
        public RatingHistoryPersonProfile()
        {
            CreateMap<RatingHistoryPerson, RatingHistoryPersonModel>();
            CreateMap<RatingHistoryPersonModel, RatingHistoryPerson>();
        }
    }
}
