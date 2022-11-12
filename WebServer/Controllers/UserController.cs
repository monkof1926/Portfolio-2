using AutoMapper;
using Portfolio_2.Domain;
using Microsoft.AspNetCore.Mvc;
using Portfolio_2.IDataService;
using Portfolio_2.DataService;


namespace WebServer.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserDataService _userDataService;
        private readonly LinkGenerator _generator;
        private readonly IMapper _mapper;

        public UserController(IUserDataService userDataService, LinkGenerator generator, IMapper mapper)
        {
            _userDataService = userDataService;
            _generator = generator;
            _mapper = mapper;
        }
    }
}
