using AutoMapper;
using Portfolio_2.DataService;
using Portfolio_2.IDataService;
using Portfolio_2.Domain;
using DataLayer.Domain;
using WebServer.Models;

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
