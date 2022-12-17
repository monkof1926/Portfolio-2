using AutoMapper;
using DataLayer.DataService;
using DataLayer.Domain;
using DataLayer.IDataService;
using DataLayer.SqlFunctions;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers
{
    [Route("api/searchsimple")]
    [ApiController]
    public class SimpleSearchFuncController : ControllerBase
    {
        private ISimpleSearchFuncDataService _searchFunc;
        private readonly LinkGenerator _generator;
        private readonly IMapper _mapper;
        public SimpleSearchFuncController(ISimpleSearchFuncDataService searchFunc, LinkGenerator generator, IMapper mapper)
        {
            _searchFunc = searchFunc;
            _generator = generator;
            _mapper = mapper;
        }
        [HttpGet(Name = nameof(GetSearchFuncSimple))]
        public IActionResult GetSearchFuncSimple(string? query = null, int type = 1)
        {
            if (type == 2 || type == 5 || type == 3)
            {
                return NotFound();
            }
            if (query == null)
            {
                return NotFound();
            }

            var results = _searchFunc.GetSearchFuncSimple(type, query);

            return Ok(results);
        }
    }
}
