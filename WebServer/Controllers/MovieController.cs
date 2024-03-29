﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;
using Microsoft.AspNetCore.Routing;
using DataLayer.Domain;
using DataLayer.IDataService;

namespace WebServer.Controllers
{
    [Route("api/movie")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private IMovieDataService _movieDataService;
        private readonly LinkGenerator _generator;
        private readonly IMapper _mapper;

        private const int MaxpageSize = 125;

        public MovieController(IMovieDataService movieDataService, LinkGenerator generator, IMapper mapper)
        {
            _movieDataService = movieDataService;
            _generator = generator;
            _mapper = mapper;
        }

        [HttpGet(Name = nameof(GetMovies))]
        public IActionResult GetMovies(int page = 0, int pageSize = 15)
        {
            var movie = _movieDataService.GetMovies(page, pageSize).Select(MovieListModel);
            var total = _movieDataService.GetNumberOfMovies();
            return Ok(Paging(page, pageSize, total, movie));
        }

        [HttpGet("{movieID}", Name = nameof(GetMovie))]
        public IActionResult GetMovie(string movieID)
        {
            var movie = _movieDataService.GetMovie(movieID);

            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                var model = MovieListModel(movie);

                return Ok(model);
            }
        }

        [HttpDelete("{movieID}")]
        public IActionResult DeleteMovie(string movieID)
        {
            var deleted = _movieDataService.DeleteMovie(movieID);

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

        private MovieListModel MovieListModel(Movie movie)
        {
            var model = _mapper.Map<MovieListModel>(movie);
            model.Url = _generator.GetUriByName(HttpContext, nameof(GetMovies), new { movie.movieID });
            return model;
        }
        private string? CreateLink(int page, int pageSize)
        {
            return _generator.GetUriByName(
            HttpContext,
                nameof(GetMovies), new { page, pageSize });

        }
    }
}
