using Application;
using Application.DataTransfer;
using Application.Interfaces;
using Implementation.Commands;
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
    public class CommentController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public CommentController(UseCaseExecutor executor)
        {
            _executor = executor;
        }
        // POST api/<CommentController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CommentMovieDto dto,
            [FromServices] CommantMovieCommand command)
        {
             _executor.ExecuteCommand(command, dto);
             return StatusCode(204);
        }

    }
}
