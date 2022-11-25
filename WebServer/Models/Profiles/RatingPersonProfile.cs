using AutoMapper;
using DataLayer.Domain;

namespace WebServer.Models.Profiles
{
    public class RatingPersonProfile : Profile
    {
        public RatingPersonProfile()
        {
            CreateMap<RatingPerson, RatingPersonModel>();
            CreateMap<RatingPersonModel, RatingPerson>();

        }
    }
}
