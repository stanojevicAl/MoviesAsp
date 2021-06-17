using Application;
using Application.DataTransfer;
using Application.Exceptions;
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
    public class UserController : ControllerBase
    {
        private readonly IApplicationUser _user;
        private readonly UseCaseExecutor _executor;

        public UserController(IApplicationUser user, UseCaseExecutor executor)
        {
            _user = user;
            _executor = executor;
        }

        // GET: api/<UserController>
        [HttpGet]
        [Authorize]
        public IActionResult Get([FromQuery] CommonSearch search,
            [FromServices] GetUserQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // PUT api/<UserController>/5
        [HttpPut]
        [Authorize]
        public IActionResult Put([FromBody] UpdateUserDto dto,
            [FromServices] UpdateUserCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return StatusCode(204);
        }

        // DELETE api/<UserController>
        [HttpDelete]
        [Authorize]
        public IActionResult Delete([FromServices] DeleteUserCommand command)
        {
             _executor.ExecuteCommand(command, _user.Id);
             return StatusCode(204);
        }
    }
}
