using AutoMapper;
using Portfolio_2.Domain;
using Microsoft.AspNetCore.Mvc;
using Portfolio_2.IDataService;
using Portfolio_2.DataService;

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
    }
}
