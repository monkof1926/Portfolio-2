using AutoMapper;
using DataLayer;
using DataLayer.DataService;
using DataLayer.Domain;
using DataLayer.IDataService;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers
{
    [Route("api/searchhistory")]
    [ApiController]
    public class SearchHistoryController : ControllerBase
    {
        private ISearchHistoryDataService _searchHistoryDataService;
        private readonly LinkGenerator _generator;
        private readonly IMapper _mapper;

        private const int MaxpageSize = 125;

        public SearchHistoryController(ISearchHistoryDataService searchHistoryDataService, LinkGenerator generator, IMapper mapper)
        {
            _searchHistoryDataService = searchHistoryDataService;
            _generator = generator;
            _mapper = mapper;
        }
        [HttpGet(Name = nameof(GetSearchHistories))]
        public IActionResult GetSearchHistories(int page = 0, int pageSize = 15)
        {
            var search = _searchHistoryDataService.GetSearchHistories(page,pageSize).Select(SearchHistoryCreateModel);
            var total = _searchHistoryDataService.GetNumberOfSearchHistories();
            return Ok(Paging(page, pageSize, total, search));
        }
        [HttpGet("{searchOrder}", Name = nameof(GetSearchHistories))]
        public IActionResult GetSearchHistories(int searchOrder)
        {
            var searchHistory = _searchHistoryDataService.GetSearchHistories(searchOrder);

            if (searchHistory == null)
            {
                return NotFound();
            }

            var model = SearchHistoryCreateModel(searchHistory);

            return Ok(model);
        }
        [HttpPost]
        public IActionResult CreateSearchHistory(SearchHistory model)
        {
            var searchHistory = _mapper.Map<SearchHistory>(model);

            _searchHistoryDataService.CreateSearchHistory(searchHistory);

            return CreatedAtRoute(null, SearchHistoryCreateModel); ;
        }
        [HttpDelete("{searchHistoryM}")]
        public IActionResult DeleteSearchHistory(int searchOrder)
        {
            var deleted = _searchHistoryDataService.DeleteSearchHistory(searchOrder);

            if (!deleted)
            {
                return NotFound();
            }
            return Ok();
        }

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

        private SearchHistoryModel SearchHistoryCreateModel(SearchHistory searchHistory)
        {
            var model = _mapper.Map<SearchHistoryModel>(searchHistory);
            model.Url = _generator.GetUriByName(HttpContext, nameof(GetSearchHistories), new { searchHistory.searchOrder });
            return model;   
        }

        private string? CreateLink(int page, int pageSize)
        {
            return _generator.GetUriByName(
            HttpContext,
                nameof(GetSearchHistories), new { page, pageSize });

        }
    }
}
