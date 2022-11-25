using AutoMapper;
using DataLayer.Domain;
namespace WebServer.Models.Profiles
{
    public class RatingHistoryMovieProfile : Profile
    {
        public RatingHistoryMovieProfile()
        {
             CreateMap<BookmarksMovie, BookmarksMovieModel>();
             CreateMap<BookmarksMovieModel, BookmarksMovie>();

        }
    }
}
