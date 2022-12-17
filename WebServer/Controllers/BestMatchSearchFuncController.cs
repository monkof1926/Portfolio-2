using AutoMapper;
using DataLayer.IDataService;
using Microsoft.AspNetCore.Mvc;

namespace WebServer.Controllers
{
    [Route("api/searchbest")]
    [ApiController]
    public class BestMatchSearchFuncController : ControllerBase
    {
        private IBestMatchSearchFuncDatService _searchfunc;
        private readonly LinkGenerator _generator;
        private readonly IMapper _mapper;

        public BestMatchSearchFuncController(IBestMatchSearchFuncDatService searchFunc, LinkGenerator generator, IMapper mapper)
        {
            _searchfunc = searchFunc;
            _generator = generator;
            _mapper = mapper;
        }
        [HttpGet(Name = nameof(GetSearchFuncBest))]
        public IActionResult GetSearchFuncBest(string? query = null, int type = 1)
        {
            if (query == null)
            {
                return NotFound();
            }
            var results = _searchfunc.GetSearchFuncBest(type, query);

            return Ok(results);
        }
    }


    
}
