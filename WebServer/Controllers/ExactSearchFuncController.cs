using AutoMapper;
using DataLayer.IDataService;
using Microsoft.AspNetCore.Mvc;

namespace WebServer.Controllers
{
    [Route("api/searchecxact")]
    [ApiController]
    public class ExactSearchFuncController : ControllerBase
    {
        private IExactSearchFuncDataService _searchfunc;
        private readonly LinkGenerator _generator;
        private readonly IMapper _mapper;
        public ExactSearchFuncController(IExactSearchFuncDataService searchFunc, LinkGenerator generator, IMapper mapper)
        {
            _searchfunc = searchFunc;
            _generator = generator;
            _mapper = mapper;
        }
        [HttpGet(Name = nameof(GetSearchFuncExact))]
        public IActionResult GetSearchFuncExact(string? query = null, int type = 5)
        {
            if (query == null)
            {
                return NotFound();
            }
            var results = _searchfunc.GetSearchFuncExact(type, query);

            return Ok(results);
        }
    }
}
