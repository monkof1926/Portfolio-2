using AutoMapper;
using Portfolio_2.Domain;
namespace WebServer.Models.Profiles
{
    public class RatingProfile : Profile
    {
        public RatingProfile()
        {
            CreateMap<Rating, RatingModel>();
            CreateMap<RatingModel, Rating>();

        }
    }
}
