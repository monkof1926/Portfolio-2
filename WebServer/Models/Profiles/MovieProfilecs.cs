using AutoMapper;
using DataLayer.Domain;

namespace WebServer.Models.Profiles
{
    public class MovieProfilecs : Profile
    {
        public MovieProfilecs()
        {
            CreateMap<Movie, MovieListModel>()
               .ForMember(dst => dst.ratingAvergeTitle, opt => opt.MapFrom(src => src.Rating.ratingAvergeTitle))
                .ForMember(dst => dst.poster, opt => opt.MapFrom(src => src.omdb.poster))
                .ForMember(dst => dst.plot, opt => opt.MapFrom(src => src.omdb.plot));
            CreateMap<MovieListModel, Movie>();
        }
    }
}
