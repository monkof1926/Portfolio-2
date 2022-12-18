using AutoMapper;
using DataLayer.Domain;

namespace WebServer.Models.Profiles
{
    public class CharactersPlayedProfile : Profile
    {
        public CharactersPlayedProfile() 
        {
            CreateMap<CharactersPlayed, CharactersPlayedListModel>();
            CreateMap<CharactersPlayedListModel, CharactersPlayed>();
        }
    }
}
