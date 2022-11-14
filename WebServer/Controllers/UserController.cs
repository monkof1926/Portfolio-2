using AutoMapper;
using DataLayer;
using DataLayer.Domain;
using DataLayer.IDataService;
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

        [HttpGet(Name = nameof(GetUsers))]
        public IActionResult GetUsers()
        {
            var user = _userDataService.GetUsers().Select(UserCreateModel);
            return Ok(user);
        }

        [HttpGet("{username}", Name = nameof(GetUsers))]
        public IActionResult GetUsers(string username)
        {
            var user = _userDataService.GetUsers(username);
            
            if (user == null)
            {
                return NotFound();
            }

            var model = UserCreateModel(user);

            return Ok(model);
        }

        [HttpPost]
        public IActionResult CreateUser(UserCreateModel model)
        {
            var user = _mapper.Map<User>(model);

            _userDataService.CreateUser(user);

            return CreatedAtRoute(null, UserCreateModel);
        }

        [HttpDelete("{username}")]
        public IActionResult DeleteUser(string username)
        {
            var deleted = _userDataService.DeleteUser(username);

            if (!deleted)
            {
                return NotFound();
            }
            return Ok();
        }

        private UserModel UserCreateModel(User user)
        {
            var model = _mapper.Map<UserModel>(user);
            model.Url = _generator.GetUriByName(HttpContext, nameof(GetUsers), new { user.username });
            return model;   
        }

        private string? CreateLink(int page, int pageSize)
        {
            return _generator.GetUriByName(
            HttpContext,
                nameof(GetUsers), new { page, pageSize });

        }

       
    }
}
