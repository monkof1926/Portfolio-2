using AutoMapper;
using DataLayer.DataService;
using DataLayer.Domain;
using DataLayer.IDataService;
using Microsoft.AspNetCore.Mvc;
using System;
using WebServer.Models;

namespace WebServer.Controllers
{
    [Route("api/characters")]
    [ApiController]
    public class CharactersPlayedController : ControllerBase
    {
        private ICharactersPlayedDataService _charactersDataService;
        private readonly LinkGenerator _generator;
        private readonly IMapper _mapper;
        public CharactersPlayedController(ICharactersPlayedDataService charactersDataService, LinkGenerator generator, IMapper mapper) 
        {
            _charactersDataService = charactersDataService;
            _generator = generator;
            _mapper = mapper;
        }
        [HttpGet("{cpnconst}", Name = nameof(GetCharacters))]
        public IActionResult GetCharacters(string cpnconst)
        {
            var character = _charactersDataService.GetCharacters(cpnconst);

            if (character == null)
            {
                return NotFound();
            }

            var model = charactersPlayedListModel(character);

            return Ok(model);
        }

        private CharactersPlayedListModel charactersPlayedListModel(CharactersPlayed charactersPlayed)
        {
            var model = _mapper.Map<CharactersPlayedListModel>(charactersPlayed);
            model.Url = _generator.GetUriByName(HttpContext, nameof(GetCharacters), new { charactersPlayed.cpnconst });
            return model;
        }
        private string? CreateLink(int page, int pageSize)
        {
            return _generator.GetUriByName(
            HttpContext,
                nameof(GetCharacters), new { page, pageSize });

        }
    }
}
