using AutoMapper;
using DataLayer.Domain;
using DataLayer.IDataService;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers
{
    public class RatingMovieController
    {
        private IRatingMovieDataService _ratingDataService;
        private readonly LinkGenerator _generator;
        private readonly IMapper _mapper;
        public RatingMovieController(IRatingMovieDataService ratingDataService, LinkGenerator generator, IMapper mapper)
        {
            _ratingDataService = ratingDataService;
            _generator = generator;
            _mapper = mapper;
        }

    }
}
