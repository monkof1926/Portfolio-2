using AutoMapper;
using Portfolio_2.Domain;
using Microsoft.AspNetCore.Mvc;
using Portfolio_2.IDataService;
using Portfolio_2.DataService;

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
