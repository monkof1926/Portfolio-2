using AutoMapper;
using DataLayer.DataService;
using DataLayer.Domain;
using DataLayer.IDataService;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers
{
    [Route("api/rating")]
    [ApiController]
    public class RatingHistoryController : ControllerBase
    {
        private IRatingHistoryDataService _ratingHistoryDataService;
        private readonly LinkGenerator _generator;
        private readonly IMapper _mapper;

        private const int MaxpageSize = 125;

        public RatingHistoryController(IRatingHistoryDataService ratingHistoryDataService, LinkGenerator generator, IMapper mapper)
        {
            _ratingHistoryDataService = ratingHistoryDataService;
            _generator = generator;
            _mapper = mapper;
        }

        [HttpGet(Name = nameof(GetRatingsHistoryPersons))]
        public IActionResult GetRatingsHistoryPersons(int page = 0, int pageSize = 15)
        {
            var user = GetUser();

            if (user == null)
            {
                return Unauthorized();
            }
            var rating = _ratingHistoryDataService.GetRatingHistoryPerson(page, pageSize).Select(RatingHistoryCreateModelPerson);
            var total = _ratingHistoryDataService.GetNumberOfUserRatingHist();
            return Ok(PagingPerson(page, pageSize, total, rating));
        }

        [HttpGet(Name = nameof(GetRatingsHistoryMovies))]
        public IActionResult GetRatingsHistoryMovies(int page = 0, int pageSize = 15)
        {
            var user = GetUser();

            if (user == null)
            {
                return Unauthorized();
            }
            var rating = _ratingHistoryDataService.GetRatingHistoryMovie(page, pageSize).Select(RatingHistoryCreateModelMovie);
            var total = _ratingHistoryDataService.GetNumberOfUserRatingHist();
            return Ok(PagingMovie(page, pageSize, total, rating));
        }

        [HttpGet("{ratingHisPersonNID}", Name = nameof(GetRatingHistoryPerson))]
        public IActionResult GetRatingHistoryPerson(string ratingnconst)
        {
            var user = GetUser();

            if (user == null)
            {
                return Unauthorized();
            }
            var rating = _ratingHistoryDataService.GetRatingHistoryPerson(ratingnconst);

            if (rating == null)
            {
                return NotFound();
            }

            var model = RatingHistoryCreateModelPerson(rating);

            return Ok(model);
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
        public IActionResult CreateRatingHistoryPerson(RatingHistoryCreateModel model)
        {
            var user = GetUser();

            if (user == null)
            {
                return Unauthorized();
            }
            var ratingHis = _mapper.Map<RatingHistory>(model);

            _ratingHistoryDataService.CreateRatingHistoryPerson(ratingHis);

            return CreatedAtRoute(null, RatingHistoryCreateModelPerson);
        }
        [HttpPost]
        public IActionResult CreateRatingHistoryMovie(RatingHistoryCreateModel model)
        {
            var user = GetUser();

            if (user == null)
            {
                return Unauthorized();
            }
            var rating = _mapper.Map<RatingHistory>(model);

            _ratingHistoryDataService.CreateRatingHistoryMovie(rating);

            return CreatedAtRoute(null, RatingHistoryCreateModelMovie);
        }
        [HttpDelete("{ratingHisPersonNID}")]
        public IActionResult DeleteRatingHistoryPerson(string ratingHisPersonNID)
        {
            var user = GetUser();

            if (user == null)
            {
                return Unauthorized();
            }
            var deleted = _ratingHistoryDataService.DeleteRatingHistoryPerson(ratingHisPersonNID);

            if (!deleted)
            {
                return NotFound();
            }
            return Ok();
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
        private object PagingPerson<T>(int page, int pageSize, int total, IEnumerable<T> items)
        {
            pageSize = pageSize > MaxpageSize ? MaxpageSize : pageSize;

            var pages = (int)Math.Ceiling((double)total / (double)pageSize);

            var first = total > 0 ? CreateLinkPerson(0, pageSize) : null;

            var prev = page > 0 ? CreateLinkPerson(page - 1, pageSize) : null;

            var current = CreateLinkPerson(page, pageSize);

            var next = page < page - 1 ? CreateLinkPerson(page + 1, pageSize) : null;

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
        private RatingHistoryModel RatingHistoryCreateModelPerson(RatingHistory ratingHistory)
        {
            var model = _mapper.Map<RatingHistoryModel>(ratingHistory);
            model.Url = _generator.GetUriByName(HttpContext, nameof(GetRatingHistoryPerson), new { ratingHistory.ratingHisPersonNID });
            return model;
        }
        private RatingHistoryModel RatingHistoryCreateModelMovie(RatingHistory ratingHistory)
        {
            var model = _mapper.Map<RatingHistoryModel>(ratingHistory);
            model.Url = _generator.GetUriByName(HttpContext, nameof(GetRatingHistoryMovie), new { ratingHistory.ratingHisMovTID });
            return model;
        }

        private string? CreateLinkPerson(int page, int pageSize)
        {
            return _generator.GetUriByName(
            HttpContext,
                nameof(GetRatingHistoryPerson), new { page, pageSize });
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
