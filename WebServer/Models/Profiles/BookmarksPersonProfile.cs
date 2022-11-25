using AutoMapper;
using DataLayer.Domain;

namespace WebServer.Models.Profiles
{
    public class BookmarksPersonProfile : Profile
    {
        public BookmarksPersonProfile()
        {
            CreateMap<BookmarksPerson, BookmarksPersonModel>();
            CreateMap<BookmarksPersonModel, BookmarksPerson>();
        }
    }
}
