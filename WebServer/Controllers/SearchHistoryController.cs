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

        public SearchHistoryController(ISearchHistoryDataService searchHistoryDataService, LinkGenerator generator, IMapper mapper)
        {
            _searchHistoryDataService = searchHistoryDataService;
            _generator = generator;
            _mapper = mapper;
        }
        [HttpGet(Name = nameof(GetSearchHistories))]
        public IActionResult GetSearchHistories()
        {
            var user = _searchHistoryDataService.GetSearchHistories().Select(SearchHistoryCreateModel);
            return Ok(user);
        }
        [HttpGet("{username}", Name = nameof(GetSearchHistories))]
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
        public IActionResult DeleteUser(int searchOrder)
        {
            var deleted = _searchHistoryDataService.DeleteSearchHistory(searchOrder);

            if (!deleted)
            {
                return NotFound();
            }
            return Ok();
        }

        private SearchHistoryModel SearchHistoryCreateModel(SearchHistory searchHistory)
        {
            var model = _mapper.Map<UserModel>(searchHistory);
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
