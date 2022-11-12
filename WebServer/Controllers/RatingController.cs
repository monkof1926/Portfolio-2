using AutoMapper;
using Portfolio_2.Domain;
using Microsoft.AspNetCore.Mvc;
using Portfolio_2.IDataService;
using Portfolio_2.DataService;

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
    }
}
