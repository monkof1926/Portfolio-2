using AutoMapper;
using DataLayer.Domain;
namespace WebServer.Models.Profiles
{
    public class BookmarksMovieProfile : Profile
    {
        public BookmarksMovieProfile()
        {
            CreateMap<BookmarksMovie, BookmarksMovieModel>();
            CreateMap<BookmarksMovieModel, BookmarksMovie>();
        }
    }
}
