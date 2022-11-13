using AutoMapper;
using DataLayer;
using DataLayer.IDataService;
using Microsoft.AspNetCore.Mvc;


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
    }
}
