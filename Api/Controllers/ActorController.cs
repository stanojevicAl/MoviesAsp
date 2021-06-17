using Application;
using Application.DataTransfer;
using Application.Interfaces;
using Application.Searches;
using Implementation.Commands;
using Implementation.Queries;
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
    public class ActorController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public ActorController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/<ActorController>
        [HttpGet]
        public IActionResult Get([FromQuery] CommonSearch search,
            [FromServices] GetActorQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // POST api/<ActorController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] ActorDto dto,
            [FromServices] CreateActorCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(201);
        }

        // PUT api/<ActorController>
        [HttpPut]
        [Authorize]
        public IActionResult Put([FromBody] ActorDto dto,
            [FromServices] UpdateActorCommand command)
        {
             _executor.ExecuteCommand(command, dto);
             return StatusCode(204);
        }

        // DELETE api/<ActorController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] DeleteActorCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return StatusCode(204);
        }
    }
}
