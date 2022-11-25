using AutoMapper;
using DataLayer.Domain;
using DataLayer.Models;
using DataLayer.IDataService;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers
{
    public class RatingMovieController : ControllerBase
    {
        private IRatingMovieDataService _ratingDataService;
        private readonly LinkGenerator _generator;
        private readonly IMapper _mapper;
        public RatingMovieController(IRatingMovieDataService ratingDataService, LinkGenerator generator, IMapper mapper)
        {
            _ratingDataService = ratingDataService;
            _generator = generator;
            _mapper = mapper;
        }
        [HttpGet(Name = nameof(GetRatingsMovies))]
        public IActionResult GetRatingsMovies()
        {
            var user = GetUser();

            if (user == null)
            {
                return Unauthorized();
            }
            var rating = _ratingDataService.GetRatingsMovies().Select(RatingCreateModelMovie);
            return Ok(rating);
        }
        [HttpGet("{ratingtonst}", Name = nameof(GetRatingMovie))]
        public IActionResult GetRatingMovie(string ratingtonst)
        {
            var user = GetUser();

            if (user == null)
            {
                return Unauthorized();
            }
            var rating = _ratingDataService.GetRatingsMovie(ratingtonst);

            if (rating == null)
            {
                return NotFound();
            }

            var model = RatingCreateModelMovie(rating);

            return Ok(model);
        }
        [HttpPost]
        public IActionResult CreateRatingMovie(RatingMovieCreateModel model)
        {
            var user = GetUser();

            if (user == null)
            {
                return Unauthorized();
            }
            var rating = _mapper.Map<RatingMovie>(model);

            _ratingDataService.CreateRatingMovie(rating);

            return CreatedAtRoute(null, RatingCreateModelMovie);
        }
        [HttpDelete("{ratingtonst}")]
        public IActionResult DeleteRatingMovie(string ratingtonst)
        {
            var user = GetUser();

            if (user == null)
            {
                return Unauthorized();
            }
            var deleted = _ratingDataService.DeleteRatingMovie(ratingtonst);

            if (!deleted)
            {
                return NotFound();
            }
            return Ok();
        }
        private RatingMovieModel RatingCreateModelMovie(RatingMovie rating)
        {
            var model = _mapper.Map<RatingMovieModel>(rating);
            model.Url = _generator.GetUriByName(HttpContext, nameof(GetRatingMovie), new { rating.ratingtonst });
            return model;
        }
        private string? CreateLinkMovie(int page, int pageSize)
        {
            return _generator.GetUriByName(
            HttpContext,
                nameof(GetRatingMovie), new { page, pageSize });
        }
        private User? GetUser()
        {
            return HttpContext.Items["User"] as User;
        }

    }
}
