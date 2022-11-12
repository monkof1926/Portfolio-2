using AutoMapper;
using Portfolio_2.Domain;

namespace WebServer.Models.Profiles
{
    public class UserProfilecs : Profile
    {
        public UserProfilecs()
        {
            CreateMap<DataLayer.Domain.User, UserModel>();
            CreateMap<UserModel, DataLayer.Domain.User>();
        }
    }
}
