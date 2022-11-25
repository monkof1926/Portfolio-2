using AutoMapper;
using DataLayer.Domain;

namespace WebServer.Models.Profiles
{
    public class RatingMovieProfile : Profile
    {
        public RatingMovieProfile()
        {
            CreateMap<RatingMovie, RatingMovieModel>();
            CreateMap<RatingMovieModel, RatingMovie>();
        }
    }
}
