using AutoMapper;
using DataLayer.DataService;
using DataLayer.Domain;
using DataLayer.IDataService;
using DataLayer.SqlFunctions;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers
{

    [Route("api/search")]
    [ApiController]

    public class SearchSqlController : ControllerBase
    {
      private ISearchFuncDataService _searchfunc;
      private readonly LinkGenerator _generator;
      private readonly IMapper _mapper;
    
        public SearchSqlController(ISearchFuncDataService searchFunc, LinkGenerator generator, IMapper mapper)
        {
            _searchfunc = searchFunc;
            _generator = generator;
            _mapper = mapper;
        }
        
        [HttpGet (Name = nameof(GetSearchFunc))]

        public IActionResult GetSearchFunc(string? query = null, int type = 1)
        {
            if(query == null)
            {
                return NotFound();
            }
            var results = _searchfunc.GetSearchFunc(type, query);

            return Ok(results);
        }
        /*
        private SearchSqlModel SearchSqlListModel(SearchFunc searchFunc)
        {
            var model = _mapper.Map<UserModel>(searchFunc);
            model.Url = _generator.GetUriByName(HttpContext, nameof(GetSearchFunc), new { searchFunc. });
            return model;
        }
        private string? CreateLink(int page, int pageSize)
        {
            return _generator.GetUriByName(
            HttpContext,
                nameof(GetSearchFunc), new { page, pageSize });

        }
        */
    }

}
