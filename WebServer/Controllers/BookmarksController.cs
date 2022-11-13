using AutoMapper;
using DataLayer.IDataService;
using Microsoft.AspNetCore.Mvc;


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
