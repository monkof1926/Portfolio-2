using AutoMapper;
using DataLayer.DataService;
using DataLayer.Domain;
using DataLayer.IDataService;
using DataLayer.SqlFunctions;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers
{

    [Route("api/searchname")]
    [ApiController]

    public class NameSearchFuncController : ControllerBase
    {
      private INameSearchFuncDataService _searchFunc;
      private readonly LinkGenerator _generator;
      private readonly IMapper _mapper;
    
        public NameSearchFuncController(INameSearchFuncDataService searchFunc, LinkGenerator generator, IMapper mapper)
        {
            _searchFunc = searchFunc;
            _generator = generator;
            _mapper = mapper;
        }
        
        [HttpGet (Name = nameof(GetSearchFunc))]
        public IActionResult GetSearchFunc(string? query = null, int type = 1)
        {
            if (type == 1|| type == 5 || type == 3 || type == 4)
            {
                return NotFound();
            }
            if (query == null)
            {
                return NotFound();
            }
            var results = _searchFunc.GetSearchFunc(type, query);

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
