using AutoMapper;
using WebServer.Models;
using DataLayer.IDataService;
using Microsoft.AspNetCore.Mvc;
using DataLayer.Domain;

namespace WebServer.Controllers
{
    [Route("api/rating")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private IRatingPersonDataService _ratingDataService;
        private readonly LinkGenerator _generator;
        private readonly IMapper _mapper;

        public RatingController(IRatingPersonDataService ratingDataService, LinkGenerator generator, IMapper mapper)
        {
            _ratingDataService = ratingDataService;
            _generator = generator;
            _mapper = mapper;
        }
        [HttpGet(Name = nameof(GetRatingsPersons))]
        public IActionResult GetRatingsPersons()
        {
            var user = GetUser();

            if (user == null)
            {
                return Unauthorized();
            }
            var rating = _ratingDataService.GetRatingsPers().Select(RatingCreateModelPerson);
            return Ok(rating);
        }

        [HttpGet(Name = nameof(GetRatingsMovies))]
        public IActionResult GetRatingsMovies()
        {
            var user = GetUser();

            if (user == null)
            {
                return Unauthorized();
            }
            var rating = _ratingDataService.GetRatingsMov().Select(RatingCreateModelMovie);
            return Ok(rating);
        }
        [HttpGet("{ratingnconst}", Name = nameof(GetRatingsPerson))]
        public IActionResult GetRatingsPerson(string ratingnconst)
        {
            var user = GetUser();

            if (user == null)
            {
                return Unauthorized();
            }
            var rating = _ratingDataService.GetRatingsPers (ratingnconst);

            if (rating == null)
            {
                return NotFound();
            }

            var model = RatingCreateModelPerson(rating);

            return Ok(model);
        }
        [HttpGet("{ratingtonst}", Name = nameof(GetRatingMovie))]
        public IActionResult GetRatingMovie(string ratingtonst)
        {
            var user = GetUser();

            if (user == null)
            {
                return Unauthorized();
            }
            var rating = _ratingDataService.GetRatingsMov(ratingtonst);

            if (rating == null)
            {
                return NotFound();
            }

            var model = RatingCreateModelPerson(rating);

            return Ok(model);
        }
        [HttpPost]
        public IActionResult CreateRatingPerson(RatingCreateModel model)
        {
            var user = GetUser();

            if (user == null)
            {
                return Unauthorized();
            }
            var rating = _mapper.Map<RatingPerson>(model);

            _ratingDataService.CreateRatingPerson(rating);

            return CreatedAtRoute(null, RatingCreateModelPerson);
        }
        [HttpPost]
        public IActionResult CreateRatingMovie(RatingCreateModel model)
        {
            var user = GetUser();

            if (user == null)
            {
                return Unauthorized();
            }
            var rating = _mapper.Map<RatingPerson>(model);

            _ratingDataService.CreateRatingMovie(rating);

            return CreatedAtRoute(null, RatingCreateModelMovie);
        }
        [HttpDelete("{ratingnconst}")]
        public IActionResult DeleteRatingPerson(string ratingnconst)
        {
            var user = GetUser();

            if (user == null)
            {
                return Unauthorized();
            }
            var deleted = _ratingDataService.DeleteRatingPerson(ratingnconst);

            if (!deleted)
            {
                return NotFound();
            }
            return Ok();
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

        private RatingModel RatingCreateModelPerson(RatingPerson rating)
        {
            var model = _mapper.Map<RatingModel>(rating);
            model.Url = _generator.GetUriByName(HttpContext, nameof(GetRatingsPerson), new { rating.ratingnconst });
            return model;
        }
        private RatingModel RatingCreateModelMovie(RatingPerson rating)
        {
            var model = _mapper.Map<RatingModel>(rating);
            model.Url = _generator.GetUriByName(HttpContext, nameof(GetRatingMovie), new { rating.ratingtonst });
            return model;
        }

        private string? CreateLinkPerson(int page, int pageSize)
        {
            return _generator.GetUriByName(
            HttpContext,
                nameof(GetRatingsPerson), new { page, pageSize });
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
