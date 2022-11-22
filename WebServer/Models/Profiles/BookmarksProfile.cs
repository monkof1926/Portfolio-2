using AutoMapper;
using DataLayer.Domain;

namespace WebServer.Models.Profiles
{
    public class BookmarksProfile : Profile
    {
        public BookmarksProfile()
        {
            CreateMap<BookmarksPerson, BookmarksModel>();
            CreateMap<BookmarksModel, BookmarksPerson>();
        }
    }
}
