using AutoMapper;
using DataLayer.Domain;
using DataLayer.IDataService;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;


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
        /*
        [HttpGet(Name = nameof(GetBookmarksPers))]
        public IActionResult GetBookmarksPers()
        {
            var user = GetUser();

            if (user == null)
            {
                return Unauthorized();
            }
            var bookmark = _bookmarkDataService.GetBookmarksPers().Select(BookmarksCreateModel);
            return Ok(bookmark);
        }

        [HttpGet(Name = nameof(GetBookmarksMov))]
        public IActionResult GetBookmarksMov()
        {
            var user = GetUser();

            if (user == null)
            {
                return Unauthorized();
            }
            var bookmark = _bookmarkDataService.GetBookmarksMov().Select(BookmarksCreateModel);
            return Ok(bookmark);
        }

        [HttpGet("{bookmarkMoviePrimarytitlerl}", Name = nameof(GetBookmarksMov))]
        public IActionResult GetBookmarksMov(string bookmarkPersonBID)
        {
            var user = GetUser();

            if (user == null)
            {
                return Unauthorized();
            }
            var book = _bookmarkDataService.GetBookmarksMov(bookmarkPersonBID);

            if (book == null)
            {
                return NotFound();
            }

            var model = BookmarksCreateModel(book);

            return Ok(model);
        }

        [HttpPost]
        public IActionResult CreateBookmarks(BookmarksCreateModel model)
        {
            var user = GetUser();

            if (user == null)
            {
                return Unauthorized();
            }
            var book = _mapper.Map<Bookmarks>(model);

            _bookmarkDataService.CreateBookmarksMovie(book);

            return CreatedAtRoute(null, BookmarksCreateModel);
        }


        [HttpDelete("{bookmarkMovieBID}")]
        public IActionResult DeleteBookmarkMovie(string bookmarkMovieBID)
        {
            var user = GetUser();

            if (user == null)
            {
                return Unauthorized();
            }
            var deleted = _bookmarkDataService.DeleteBookmarksMovie(bookmarkMovieBID);

            if (!deleted)
            {
                return NotFound();
            }
            return Ok();
        }

        private BookmarksModel BookmarksCreateModel(Bookmarks bookmarks)
        {
            var model = _mapper.Map<BookmarksModel>(bookmarks);
            model.Url = _generator.GetUriByName(HttpContext, nameof(GetBookmarksMov), new { bookmarks.bookmarkMovieBID });
            return model;
        }

        private string? CreateLink(int page, int pageSize)
        {
            return _generator.GetUriByName(
            HttpContext,
                nameof(GetBookmarksPers), new { page, pageSize });

        }
        private User? GetUser()
        {
            return HttpContext.Items["User"] as User;
        }
        */
    }
}
