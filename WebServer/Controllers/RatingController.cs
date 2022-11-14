using AutoMapper;
using WebServer.Models;
using DataLayer.IDataService;
using Microsoft.AspNetCore.Mvc;
using DataLayer.Domain;
using DataLayer.DataService;

namespace WebServer.Controllers
{
    [Route("api/rating")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private IRatingDataService _ratingDataService;
        private readonly LinkGenerator _generator;
        private readonly IMapper _mapper;

        public RatingController(IRatingDataService ratingDataService, LinkGenerator generator, IMapper mapper)
        {
            _ratingDataService = ratingDataService;
            _generator = generator;
            _mapper = mapper;
        }
        [HttpGet(Name = nameof(GetRatingsPerson))]
        public IActionResult GetRatingsPerson()
        {
            var rating = _ratingDataService.GetRatingsPers().Select(RatingCreateModelPerson);
            return Ok(rating);
        }

        [HttpGet(Name = nameof(GetRatingsMovie))]
        public IActionResult GetRatingsMovie()
        {
            var rating = _ratingDataService.GetRatingsMov().Select(RatingCreateModelMovie);
            return Ok(rating);
        }
        [HttpGet("{ratingnconst}", Name = nameof(GetRatingsPerson))]
        public IActionResult GetRatingsPerson(string ratingnconst)
        {
            var rating = _ratingDataService.GetRatingsPers (ratingnconst);

            if (rating == null)
            {
                return NotFound();
            }

            var model = RatingCreateModelPerson(rating);

            return Ok(model);
        }
        [HttpGet("{ratingtonst}", Name = nameof(GetRatingsMovie))]
        public IActionResult GetRatingMovie(string ratingtonst)
        {
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
            var rating = _mapper.Map<Rating>(model);

            _ratingDataService.CreateRatingPerson(rating);

            return CreatedAtRoute(null, RatingCreateModelPerson);
        }
        [HttpPost]
        public IActionResult CreateRatingMovie(RatingCreateModel model)
        {
            var rating = _mapper.Map<Rating>(model);

            _ratingDataService.CreateRatingMovie(rating);

            return CreatedAtRoute(null, RatingCreateModelMovie);
        }
        [HttpDelete("{ratingnconst}")]
        public IActionResult DeleteRatingPerson(string ratingnconst)
        {
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
            var deleted = _ratingDataService.DeleteRatingMovie(ratingtonst);

            if (!deleted)
            {
                return NotFound();
            }
            return Ok();
        }

        private RatingModel RatingCreateModelPerson(Rating rating)
        {
            var model = _mapper.Map<RatingModel>(rating);
            model.Url = _generator.GetUriByName(HttpContext, nameof(GetRatingsPerson), new { rating.ratingnconst });
            return model;
        }
        private RatingModel RatingCreateModelMovie(Rating rating)
        {
            var model = _mapper.Map<RatingModel>(rating);
            model.Url = _generator.GetUriByName(HttpContext, nameof(GetRatingsMovie), new { rating.ratingtonst });
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
                nameof(GetRatingsMovie), new { page, pageSize });
        }
    }
}
