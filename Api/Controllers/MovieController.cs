using Microsoft.AspNetCore.Mvc;
using Application;
using Application.DataTransfer;
using Application.Interfaces;
using Application.Interfaces.Queries;
using Application.Searches;
using Implementation.Commands;
using Implementation.Queries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {

        private readonly UseCaseExecutor _executor;

        public MovieController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/<MovieController>
        [HttpGet]
        public IActionResult Get([FromQuery] MovieSearch search,
            [FromServices] GetMoviesQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // POST api/<MovieController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromForm] MovieDto dto,
            [FromServices] CreateMovieCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<MovieController>
        [HttpPut]
        [Authorize]
        public IActionResult Put([FromForm] MovieDto dto,
            [FromServices] UpdateMovieCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(204);
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] DeleteMovieCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return StatusCode(204);
        }
    }
}
