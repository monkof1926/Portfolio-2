using AutoMapper;
using DataLayer.Domain;

namespace WebServer.Models.Profiles
{
    public class PersonProfile : Profile  
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonListModel>();
                /*
                .ForMember(dst => dst.charactersplayed, opt => opt.MapFrom(src => src.characters_played.charactersplayed))
                .ForMember(dst => dst.category, opt => opt.MapFrom(src => src.characters_played.category));
                */

            CreateMap<PersonListModel, Person>();
        }
    }
}
