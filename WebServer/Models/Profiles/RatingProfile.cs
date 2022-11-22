using AutoMapper;
using DataLayer.Domain;

namespace WebServer.Models.Profiles
{
    public class RatingProfile : Profile
    {
        public RatingProfile()
        {
            CreateMap<RatingPerson, RatingModel>();
            CreateMap<RatingModel, RatingPerson>();

        }
    }
}
