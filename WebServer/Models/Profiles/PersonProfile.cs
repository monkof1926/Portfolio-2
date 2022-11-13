using AutoMapper;
using DataLayer.Domain;

namespace WebServer.Models.Profiles
{
    public class PersonProfile : Profile  
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonListModel>()
                .ForMember(dst => dst.fullname, opt => opt.MapFrom(src => src.fullName));

            CreateMap<Person, PersonModel>();
        }
    }
}
