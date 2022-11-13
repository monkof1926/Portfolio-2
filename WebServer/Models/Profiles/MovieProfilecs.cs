using AutoMapper;
using DataLayer.Domain;

namespace WebServer.Models.Profiles
{
    public class MovieProfilecs : Profile
    {
        public MovieProfilecs()
        {
            CreateMap<Movie, MovieListModel>()
                .ForMember(dst => dst.title, opt => opt.MapFrom(src => src.title));

            CreateMap<Movie, MovieModel>();
        }
    }
}
