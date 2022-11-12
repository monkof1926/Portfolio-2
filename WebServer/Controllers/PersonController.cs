using AutoMapper;
using Portfolio_2.Domain;
using Microsoft.AspNetCore.Mvc;
using Portfolio_2.IDataService;
using Portfolio_2.DataService;

namespace WebServer.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPersonDataService _personDataService;
        private readonly LinkGenerator _generator;
        private readonly IMapper _mapper;

        public PersonController(PersonDataService personDataService, LinkGenerator generator, IMapper mapper)
        {
            _personDataService = personDataService;
            _generator = generator;
            _mapper = mapper;
        }
    }
}
