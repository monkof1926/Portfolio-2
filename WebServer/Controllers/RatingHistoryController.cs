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

        public RatingHistoryController(IRatingHistoryDataService ratingHistoryDataService, LinkGenerator generator, IMapper mapper)
        {
            _ratingHistoryDataService = ratingHistoryDataService;
            _generator = generator;
            _mapper = mapper;
        }
        [HttpGet(Name = nameof(GetRatingsHistoryPerson))]
        public IActionResult GetRatingsHistoryPerson()
        {
            var rating = _ratingHistoryDataService.GetRatingHistoriesPerson().Select(RatingHistoryCreateModelPerson);
            return Ok(rating);
        }

        [HttpGet(Name = nameof(GetRatingsHistoryMovie))]
        public IActionResult GetRatingsHistoryMovie()
        {
            var rating = _ratingHistoryDataService.GetRatingHistoriesMovie().Select(RatingHistoryCreateModelMovie);
            return Ok(rating);
        }
        [HttpGet("{ratingHisPersonNID}", Name = nameof(GetRatingsHistoryPerson))]
        public IActionResult GetRatingHistoryPerson(string ratingnconst)
        {
            var rating = _ratingHistoryDataService.GetRatingHistoryPerson(ratingnconst);

            if (rating == null)
            {
                return NotFound();
            }

            var model = RatingHistoryCreateModelPerson(rating);

            return Ok(model);
        }
        [HttpGet("{ratingHisMovTID}", Name = nameof(GetRatingsHistoryMovie))]
        public IActionResult GetRatingHistoryMovie(string ratingtonst)
        {
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
            var ratingHis = _mapper.Map<RatingHistory>(model);

            _ratingHistoryDataService.CreateRatingHistoryPerson(ratingHis);

            return CreatedAtRoute(null, RatingHistoryCreateModelPerson);
        }
        [HttpPost]
        public IActionResult CreateRatingHistoryMovie(RatingHistoryCreateModel model)
        {
            var rating = _mapper.Map<RatingHistory>(model);

            _ratingHistoryDataService.CreateRatingHistoryMovie(rating);

            return CreatedAtRoute(null, RatingHistoryCreateModelMovie);
        }
        [HttpDelete("{ratingHisPersonNID}")]
        public IActionResult DeleteRatingHistoryPerson(string ratingHisPersonNID)
        {
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
            var deleted = _ratingHistoryDataService.DeleteRatingHistoryMovie(ratingHisMovTID);

            if (!deleted)
            {
                return NotFound();
            }
            return Ok();
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
                nameof(GetRatingsHistoryPerson), new { page, pageSize });
        }
        private string? CreateLinkMovie(int page, int pageSize)
        {
            return _generator.GetUriByName(
            HttpContext,
                nameof(GetRatingsHistoryMovie), new { page, pageSize });
        }
    }
}
