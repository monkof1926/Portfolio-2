using AutoMapper;
using DataLayer.Domain;
using DataLayer.IDataService;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers
{
    [Route("api/searchbest")]
    [ApiController]
    public class BestMatchSearchFuncController : ControllerBase
    {
        private IBestMatchSearchFuncDatService _searchfunc;
        private readonly LinkGenerator _generator;
        private readonly IMapper _mapper;

        private const int MaxpageSize = 12500;

        public BestMatchSearchFuncController(IBestMatchSearchFuncDatService searchfunc, LinkGenerator generator, IMapper mapper)
        {
            _searchfunc = searchfunc;
            _generator = generator;
            _mapper = mapper;

        }

        [HttpGet(Name = nameof(GetSearchFuncBest))]
        public IActionResult GetSearchFuncBest( int? type = 3, string? query = null /*,int page = 0, int pageSize = 15*/)
        {
          /*  
            var model = _searchfunc.GetSearchFuncBest(type, query, page, pageSize).Select(BestMatchSearchFuncListModel) ;
            var total = _searchfunc.GetNumberOfSearch();
          */

            if (query == null)
            {
                return NotFound();
            }

            var results = _searchfunc.GetSearchFuncBest(type, query);

            //return Ok(Paging(page,pageSize,model,total));
            return Ok(results);
        }
      /*  
        private object Paging<T>(int page, int pageSize, int total, IEnumerable<T> items)
        {
            pageSize = pageSize > MaxpageSize ? MaxpageSize : pageSize;

            var pages = (int)Math.Ceiling((double)total / (double)pageSize);

            var first = total > 0 ? CreateLink(0, pageSize) : null;

            var prev = page > 0 ? CreateLink(page - 1, pageSize) : null;

            var current = CreateLink(page, pageSize);

            var next = page < page - 1 ? CreateLink(page + 1, pageSize) : null;

            var result = new
            {
                first,
                prev,
                next,
                current,
                total,
                pages,
                items
            };
            return result;
        }
        private BestMatchSearchFuncListModel BestMatchSearchFuncListModel(BestMatchSearchFuncListModel bestMatchSearchFuncListModel)
        {
            var model = _mapper.Map<BestMatchSearchFuncListModel>(bestMatchSearchFuncListModel);
            model.Url = _generator.GetUriByName(HttpContext, nameof(GetSearchFuncBest), new { bestMatchSearchFuncListModel.searchword});
            return model;
        }
        private string? CreateLink(int page, int pageSize)
        {
            return _generator.GetUriByName(
            HttpContext,
                nameof(GetSearchFuncBest), new { page, pageSize });

        }
        */
    }


    
}
