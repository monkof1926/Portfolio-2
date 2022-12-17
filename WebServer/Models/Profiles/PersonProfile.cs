using AutoMapper;
using DataLayer.Domain;

namespace WebServer.Models.Profiles
{
    public class PersonProfile : Profile  
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonListModel>()
                .ForMember(dst => dst.charactersplayed, opt => opt.MapFrom(src => src.charaters_played.charactersplayed))
                .ForMember(dst => dst.category, opt => opt.MapFrom(src => src.charaters_played.category));

            CreateMap<Person, PersonModel>();
        }
    }
}
