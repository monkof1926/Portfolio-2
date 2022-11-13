using AutoMapper;
using DataLayer.IDataService;
using Microsoft.AspNetCore.Mvc;


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
