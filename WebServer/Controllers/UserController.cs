using AutoMapper;
using DataLayer;
using DataLayer.Domain;
using DataLayer.IDataService;
using DataLayer.DataService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;




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

        [HttpGet(Name = nameof())]
       
    }
}
