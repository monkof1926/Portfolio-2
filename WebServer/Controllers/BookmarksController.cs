using AutoMapper;
using DataLayer.DataService;
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

        [HttpGet(Name = nameof(GetBookmarks))]
        public IActionResult GetBookmarks()
        {
            var user = _bookmarkDataService.GetBookmarks().Select(x => x.BookmarksCreateModel(x));
            return Ok(user);
        }

        [HttpGet("{bookmarkMoviePrimarytitlerl}", Name = nameof(GetBookmarks))]
        public IActionResult GetBookmarks(string bookmarkPersonBID)
        {
            var book = _bookmarkDataService.GetBookmarks(bookmarkPersonBID);

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
            var book = _mapper.Map<Bookmarks>(model);

            _bookmarkDataService.CreateBookmarksMovie(book);

            return CreatedAtRoute(null, BookmarksCreateModel));
        }


        [HttpDelete("{bookmarkMovieBID}")]
        public IActionResult DeleteBookmarkMovie(string bookmarkMovieBID)
        {
            var deleted = _bookmarkDataService.DeleteBookmarksMovie(bookmarkMovieBID);

            if (!deleted)
            {
                return NotFound();
            }
            return Ok();
        }

        private BookmarksModel BookmarksCreateModel(Bookmarks bookmarks)
        {
            var model = _mapper.Map<UserModel>(bookmarks);
            model.Url = _generator.GetUriByName(HttpContext, nameof(GetBookmarks), new { bookmarks.bookmarkMovieBID });
            return model;
        }

        private string? CreateLink(int page, int pageSize)
        {
            return _generator.GetUriByName(
            HttpContext,
                nameof(GetBookmarks), new { page, pageSize });

        }

    }
}
