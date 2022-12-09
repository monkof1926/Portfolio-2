using AutoMapper;
using DataLayer.Domain;

namespace WebServer.Models.Profiles
{
    public class MovieProfilecs : Profile
    {
        public MovieProfilecs()
        {
            CreateMap<Movie, MovieListModel>()
               .ForMember(dst => dst.ratingAvergeTitle, opt => opt.MapFrom(src => src.Rating.ratingAvergeTitle));

            CreateMap<Movie, MovieModel>();
        }
    }
}
