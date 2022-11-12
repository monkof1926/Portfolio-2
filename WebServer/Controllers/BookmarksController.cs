using AutoMapper;
using Portfolio_2.Domain;
using Microsoft.AspNetCore.Mvc;
using Portfolio_2.IDataService;
using Portfolio_2.DataService;

namespace WebServer.Controllers
{
    [Route("api/bookmarks")]
    [ApiController]
    public class BookmarksController : ControllerBase
    {
        private IBookmarkDataService _bookmarkDataService;
        private readonly LinkGenerator _generator;
        private readonly IMapper _mapper;

        public BookmarksController(IBookmarkDataService bookmarkDataService, LinkGenerator generator, IMapper mapper)
        {
            _bookmarkDataService = bookmarkDataService;
            _generator = generator;
            _mapper = mapper;
        }
    }
}
