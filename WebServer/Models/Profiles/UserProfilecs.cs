using AutoMapper;
using DataLayer.Domain;


namespace WebServer.Models.Profiles
{
    public class UserProfilecs : Profile
    {
        public UserProfilecs()
        {
            CreateMap<User, UserModel>();
            CreateMap<UserModel, DataLayer.Domain.User>();
        }
    }
}
