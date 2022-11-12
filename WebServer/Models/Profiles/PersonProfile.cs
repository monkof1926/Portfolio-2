using AutoMapper;
using Portfolio_2.DataService;
using Portfolio_2.IDataService;
using Portfolio_2.Domain;
using DataLayer.Domain;
using WebServer.Models;

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
