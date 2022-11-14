using AutoMapper;
using DataLayer.IDataService;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

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
        private MovieModel MovieCreateModel(Movies movie)
        {
            var model = _mapper.Map<MovieModel>();
            model.Url = _generator.GetUriByName(HttpContext, nameof(GetMovies), new { user.username });
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
