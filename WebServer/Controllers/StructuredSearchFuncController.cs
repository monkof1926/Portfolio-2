using AutoMapper;
using DataLayer.DataService;
using DataLayer.Domain;
using DataLayer.IDataService;
using DataLayer.SqlFunctions;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Emit;
using WebServer.Models;

namespace WebServer.Controllers
{
    [Route("api/searchstructured")]
    [ApiController]
   
    public class StructuredSearchFuncController : ControllerBase
    {
        private IStructuredSearchFuncDataService _searchFunc;
        private readonly LinkGenerator _generator;
        private readonly IMapper _mapper;
        public StructuredSearchFuncController(IStructuredSearchFuncDataService searchFunc, LinkGenerator generator, IMapper mapper)
        {
            _searchFunc = searchFunc;
            _generator = generator;
            _mapper = mapper;
        }
        [HttpGet(Name = nameof(GetSearchFuncStructured))]
        public IActionResult GetSearchFuncStructured(string? query = null, int type = 4)
        {
            if (type == 2 || type == 5 || type == 3)
            {
                return NotFound();
            }
            if (query == null)
            {
                return NotFound();
            }

            var results = _searchFunc.GetSearchFuncStructured(type, query);

            return Ok(results);
        }

    }
}
