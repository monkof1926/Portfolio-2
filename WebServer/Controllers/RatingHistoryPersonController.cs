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
    public class RatingHistoryPersonController : ControllerBase
    {
        private IRatingHistoryPersonDataService _ratingHistoryDataService;
        private readonly LinkGenerator _generator;
        private readonly IMapper _mapper;

        private const int MaxpageSize = 125;

        public RatingHistoryPersonController(IRatingHistoryPersonDataService ratingHistoryDataService, LinkGenerator generator, IMapper mapper)
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
            var rating = _ratingHistoryDataService.GetRatingHistoryPersons(page, pageSize).Select(RatingHistoryCreateModelPerson);
            var total = _ratingHistoryDataService.GetNumberOfUserRatingHist();
            return Ok(PagingPerson(page, pageSize, total, rating));
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
        [HttpPost]
        public IActionResult CreateRatingHistoryPerson(RatingHistoryPersonCreateModel model)
        {
            var user = GetUser();

            if (user == null)
            {
                return Unauthorized();
            }
            var ratingHis = _mapper.Map<RatingHistoryPerson>(model);

            _ratingHistoryDataService.CreateRatingHistoryPerson(ratingHis);

            return CreatedAtRoute(null, RatingHistoryCreateModelPerson);
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
        private RatingHistoryPersonModel RatingHistoryCreateModelPerson(RatingHistoryPerson ratingHistory)
        {
            var model = _mapper.Map<RatingHistoryPersonModel>(ratingHistory);
            model.Url = _generator.GetUriByName(HttpContext, nameof(GetRatingHistoryPerson), new { ratingHistory.ratingHisPersonNID });
            return model;
        }
        private string? CreateLinkPerson(int page, int pageSize)
        {
            return _generator.GetUriByName(
            HttpContext,
                nameof(GetRatingHistoryPerson), new { page, pageSize });
        }
        private User? GetUser()
        {
            return HttpContext.Items["User"] as User;
        }
    }
}
