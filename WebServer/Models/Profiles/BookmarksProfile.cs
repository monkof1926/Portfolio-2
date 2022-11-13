using AutoMapper;
using DataLayer.Domain;

namespace WebServer.Models.Profiles
{
    public class BookmarksProfile : Profile
    {
        public BookmarksProfile()
        {
            CreateMap<Bookmarks, BookmarksModel>();
            CreateMap<BookmarksModel, Bookmarks>();
        }
    }
}
