using AutoMapper;
using DataLayer.Domain;
using DataLayer.IDataService;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers
{
    [Route("api/bookmarksMovie")]
    [ApiController]
    public class BookmarksMovieController : ControllerBase
    {
        private IBookmarkMovieDataService _bookmarkDataService;
        private readonly LinkGenerator _generator;
        private readonly IMapper _mapper;

        public BookmarksMovieController (IBookmarkMovieDataService bookmarkMovieDataService, LinkGenerator generator, IMapper mapper)
        {
            _bookmarkDataService = bookmarkMovieDataService;
            _generator = generator;
            _mapper = mapper;
        }
        [HttpGet(Name = nameof(GetBookmarksMovies))]
        public IActionResult GetBookmarksMovies()
        {
            var user = GetUser();

            if (user == null)
            {
                return Unauthorized();
            }
            var bookmark = _bookmarkDataService.GetBookmarksMovies().Select(BookmarksCreateModel);
            return Ok(bookmark);
        }
        [HttpGet("{bookmarkMoviePrimarytitlerl}", Name = nameof(GetBookmarksMovie))]
        public IActionResult GetBookmarksMovie(string bookmarkMovieBID)
        {
            var user = GetUser();

            if (user == null)
            {
                return Unauthorized();
            }
            var book = _bookmarkDataService.GetBookmarksMovie(bookmarkMovieBID);

            if (book == null)
            {
                return NotFound();
            }

            var model = BookmarksCreateModel(book);

            return Ok(model);
        }
        [HttpPost]
        public IActionResult CreateBookmarks(BookmarksMovieCreateModel model)
        {
            var user = GetUser();

            if (user == null)
            {
                return Unauthorized();
            }
            var book = _mapper.Map<BookmarksMovie>(model);

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

        private BookmarksMovieModel BookmarksCreateModel(BookmarksMovie bookmarks)
        {
            var model = _mapper.Map<BookmarksMovieModel>(bookmarks);
            model.Url = _generator.GetUriByName(HttpContext, nameof(GetBookmarksMovie), new { bookmarks.bookmarkMovieBID });
            return model;
        }

        private string? CreateLink(int page, int pageSize)
        {
            return _generator.GetUriByName(
            HttpContext,
                nameof(GetBookmarksMovie), new { page, pageSize });

        }
        private User? GetUser()
        {
            return HttpContext.Items["User"] as User;
        }
    }
}
