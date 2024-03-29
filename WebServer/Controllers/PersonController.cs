﻿using AutoMapper;
using DataLayer.DataService;
using DataLayer.Domain;
using DataLayer.IDataService;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPersonDataService _personDataService;
        private readonly LinkGenerator _generator;
        private readonly IMapper _mapper;

        private const int MaxpageSize = 125;

        public PersonController(IPersonDataService personDataService, LinkGenerator generator, IMapper mapper)
        {
            _personDataService = personDataService;
            _generator = generator;
            _mapper = mapper;
        }

        [HttpGet(Name = nameof(GetPersons))]
        public IActionResult GetPersons(int page = 0, int pageSize = 15)
        {
            var movie = _personDataService.GetPersons(page, pageSize).Select(PersonListModel);
            var total = _personDataService.GetNumberOfPersons();
            return Ok(Paging(page, pageSize, total, movie));
        }

        [HttpGet("{nameID}", Name = nameof(GetPerson))]
        public IActionResult GetPerson(string nameID)
        {
            var person = _personDataService.GetPerson(nameID);

            if (person == null)
            {
                return NotFound();
            }
            else
            {
                var model = PersonListModel(person);

                return Ok(model);
            }
        }

        [HttpDelete("{movieID}")]
        public IActionResult DeletePerson(string nameID)
        {
            var deleted = _personDataService.DeletePerson(nameID);

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

        private PersonListModel PersonListModel(Person person)
        {
            var model = _mapper.Map<PersonListModel>(person);
            model.Url = _generator.GetUriByName(HttpContext, nameof(GetPerson), new { person.nameID });
            return model;
        }
        private string? CreateLink(int page, int pageSize)
        {
            return _generator.GetUriByName(
            HttpContext,
                nameof(GetPersons), new { page, pageSize });

        }
    }
}
