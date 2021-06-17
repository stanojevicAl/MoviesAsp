using Application;
using Application.DataTransfer;
using Application.Interfaces;
using Application.Searches;
using Implementation.Commands;
using Implementation.Queries;
using Implementation.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public GenreController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/<GenreController>
        [HttpGet]
        public IActionResult Get([FromQuery] CommonSearch search,
            [FromServices] GetGenreQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // POST api/<GenreController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] GenreDto dto,
            [FromServices] CreateGenreCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(204);
        }

        // PUT api/<GenreController>
        [HttpPut]
        [Authorize]
        public IActionResult Put([FromBody] GenreDto dto,
            [FromServices] UpdateGenreCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(204);
        }

        // DELETE api/<GenreController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] DeleteGenreCommand command)
        {
             _executor.ExecuteCommand(command, id);
             return StatusCode(204);          
        }
    }
}
