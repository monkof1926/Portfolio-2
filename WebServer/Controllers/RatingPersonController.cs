using AutoMapper;
using WebServer.Models;
using Microsoft.AspNetCore.Mvc;
using DataLayer.Models;
using DataLayer.Domain;
using DataLayer.IDataService;

namespace WebServer.Controllers
{
    [Route("api/ratingPerson")]
    [ApiController]
    public class RatingPersonController : ControllerBase
    {
        private IRatingPersonDataService _ratingDataService;
        private readonly LinkGenerator _generator;
        private readonly IMapper _mapper;

        public RatingPersonController(IRatingPersonDataService ratingDataService, LinkGenerator generator, IMapper mapper)
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
            var rating = _ratingDataService.GetRatingsPersons().Select(RatingCreateModelPerson);
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
            var rating = _ratingDataService.GetRatingsPerson (ratingnconst);

            if (rating == null)
            {
                return NotFound();
            }

            var model = RatingCreateModelPerson(rating);

            return Ok(model);
        }
        [HttpPost]
        public IActionResult CreateRatingPerson(RatingPersonCreateModel model)
        {
            var user = GetUser();

            if (user == null)
            {
                return Unauthorized();
            }
            var rating = _mapper.Map<RatingPerson>(model);

            _ratingDataService.CreateRatingPerson(rating);

            return CreatedAtRoute(null, CreateRatingPerson);
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
        private RatingPersonModel RatingCreateModelPerson(RatingPerson rating)
        {
            var model = _mapper.Map<RatingPersonModel>(rating);
            model.Url = _generator.GetUriByName(HttpContext, nameof(GetRatingsPerson), new { rating.ratingnconst });
            return model;
        }
        private string? CreateLinkPerson(int page, int pageSize)
        {
            return _generator.GetUriByName(
            HttpContext,
                nameof(GetRatingsPerson), new { page, pageSize });
        }
        private User? GetUser()
        {
            return HttpContext.Items["User"] as User;
        }
    }
}
