using AutoMapper;
using DataLayer.Domain;
using DataLayer.IDataService;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;


namespace WebServer.Controllers
{
    [Route("api/bookmarksPerson")]
    [ApiController]
    public class BookmarksPersonController : ControllerBase
    {
        private IBookmarkPersonDataService _bookmarkDataService;
        private readonly LinkGenerator _generator;
        private readonly IMapper _mapper;

        public BookmarksPersonController(IBookmarkPersonDataService bookmarkPersonDataService, LinkGenerator generator, IMapper mapper)
        {
            _bookmarkDataService = bookmarkPersonDataService;
            _generator = generator;
            _mapper = mapper;
        }
        
        [HttpGet(Name = nameof(GetBookmarksPersons))]
        public IActionResult GetBookmarksPersons()
        {
            var user = GetUser();

            if (user == null)
            {
                return Unauthorized();
            }
            var bookmark = _bookmarkDataService.GetBookmarksPersons().Select(BookmarksPersonCreateModel);
            return Ok(bookmark);
        }
        [HttpGet("{bookmarkMoviePrimarytitler}", Name = nameof(GetBookmarksPerson))]
        public IActionResult GetBookmarksPerson(string bookmarkPersonBID)
        {
            var user = GetUser();

            if (user == null)
            {
                return Unauthorized();
            }
            var book = _bookmarkDataService.GetBookmarksPerson(bookmarkPersonBID);

            if (book == null)
            {
                return NotFound();
            }

            var model = BookmarksPersonCreateModel(book);

            return Ok(model);
        }

        [HttpPost]
        public IActionResult CreateBookmarks(BookmarksPersonCreateModel model)
        {
            var user = GetUser();

            if (user == null)
            {
                return Unauthorized();
            }
            var book = _mapper.Map<BookmarksPerson>(model);

            _bookmarkDataService.CreateBookmarksPerson(book);

            return CreatedAtRoute(null, CreateBookmarks);
        }


        [HttpDelete("{bookmarkPersonBID}")]
        public IActionResult DeleteBookmarkMovie(string bookmarkPersonBID)
        {
            var user = GetUser();

            if (user == null)
            {
                return Unauthorized();
            }
            var deleted = _bookmarkDataService.DeleteBookmarksPerson(bookmarkPersonBID);

            if (!deleted)
            {
                return NotFound();
            }
            return Ok();
        }

        private BookmarksPersonModel BookmarksPersonCreateModel(BookmarksPerson bookmarks)
        {
            var model = _mapper.Map<BookmarksPersonModel>(bookmarks);
            model.Url = _generator.GetUriByName(HttpContext, nameof(GetBookmarksPersons), new { bookmarks.bookmarkPersonBID });
            return model;
        }

        private string? CreateLink(int page, int pageSize)
        {
            return _generator.GetUriByName(
            HttpContext,
                nameof(GetBookmarksPersons), new { page, pageSize });

        }
        private User? GetUser()
        {
            return HttpContext.Items["User"] as User;
        }
        
    }
}
