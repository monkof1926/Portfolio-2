using AutoMapper;
using DataLayer.IDataService;
using Microsoft.AspNetCore.Mvc;

namespace WebServer.Controllers
{
    [Route("api/movie")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private IMovieDataService _movieDataService;
        private readonly LinkGenerator _generator;
        private readonly IMapper _mapper;

        public MovieController(IMovieDataService movieDataService, LinkGenerator generator, IMapper mapper)
        {
            _movieDataService = movieDataService;
            _generator = generator;
            _mapper = mapper;
        }
    }
}
