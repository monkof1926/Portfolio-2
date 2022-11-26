using AutoMapper;
using DataLayer.DataService;
using DataLayer.Domain;
using DataLayer.IDataService;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers
{
    [Route("api/ratingHistoryMovie")]
    [ApiController]
    public class RatingHistoryMovieController : ControllerBase
    {
        private IRatingHistoryMovieDataService _ratingHistoryDataService;
        private readonly LinkGenerator _generator;
        private readonly IMapper _mapper;

        private const int MaxpageSize = 125;
        public RatingHistoryMovieController(IRatingHistoryMovieDataService ratingHistoryDataService, LinkGenerator generator, IMapper mapper)
        {
            _ratingHistoryDataService = ratingHistoryDataService;
            _generator = generator;
            _mapper = mapper;
        }
        [HttpGet(Name = nameof(GetRatingsHistoryMovies))]
        public IActionResult GetRatingsHistoryMovies(int page = 0, int pageSize = 15)
        {
            var user = GetUser();

            if (user == null)
            {
                return Unauthorized();
            }
            var rating = _ratingHistoryDataService.GetRatingHistoryMovies(page, pageSize).Select(RatingHistoryCreateModelMovie);
            var total = _ratingHistoryDataService.GetNumberOfUserRatingHist();
            return Ok(PagingMovie(page, pageSize, total, rating));
        }
        [HttpGet("{ratingHisMovTID}", Name = nameof(GetRatingHistoryMovie))]
        public IActionResult GetRatingHistoryMovie(string ratingtonst)
        {
            var user = GetUser();

            if (user == null)
            {
                return Unauthorized();
            }
            var rating = _ratingHistoryDataService.GetRatingHistoryMovie(ratingtonst);

            if (rating == null)
            {
                return NotFound();
            }

            var model = RatingHistoryCreateModelMovie(rating);

            return Ok(model);
        }
        [HttpPost]
        public IActionResult CreateRatingHistoryMovie(RatingHistoryMovieCreateModel model)
        {
            var user = GetUser();

            if (user == null)
            {
                return Unauthorized();
            }
            var rating = _mapper.Map<RatingHistoryMovie>(model);

            _ratingHistoryDataService.CreateRatingHistoryMovie(rating);

            return CreatedAtRoute(null, RatingHistoryCreateModelMovie);
        }
        [HttpDelete("{ratingHisMovTID}")]
        public IActionResult DeleteRatingHistoryMovie(string ratingHisMovTID)
        {
            var user = GetUser();

            if (user == null)
            {
                return Unauthorized();
            }
            var deleted = _ratingHistoryDataService.DeleteRatingHistoryMovie(ratingHisMovTID);

            if (!deleted)
            {
                return NotFound();
            }
            return Ok();
        }
        private object PagingMovie<T>(int page, int pageSize, int total, IEnumerable<T> items)
        {
            pageSize = pageSize > MaxpageSize ? MaxpageSize : pageSize;

            var pages = (int)Math.Ceiling((double)total / (double)pageSize);

            var first = total > 0 ? CreateLinkMovie(0, pageSize) : null;

            var prev = page > 0 ? CreateLinkMovie(page - 1, pageSize) : null;

            var current = CreateLinkMovie(page, pageSize);

            var next = page < page - 1 ? CreateLinkMovie(page + 1, pageSize) : null;

            var result = new
            {
                first,
                prev,
                next,
                current,
                total,
                pages,
                items
            };
            return result;
        }
        private RatingHistoryMovieModel RatingHistoryCreateModelMovie(RatingHistoryMovie ratingHistory)
        {
            var model = _mapper.Map<RatingHistoryMovieModel>(ratingHistory);
            model.Url = _generator.GetUriByName(HttpContext, nameof(GetRatingHistoryMovie), new { ratingHistory.ratingHisMovTID });
            return model;
        }
        private string? CreateLinkMovie(int page, int pageSize)
        {
            return _generator.GetUriByName(
            HttpContext,
                nameof(GetRatingHistoryMovie), new { page, pageSize });
        }
        private User? GetUser()
        {
            return HttpContext.Items["User"] as User;
        }
    }
}
