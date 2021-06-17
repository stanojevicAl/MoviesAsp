using Application;
using Application.DataTransfer;
using Implementation.Commands.UserCommands;
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
    public class VerificationController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public VerificationController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // POST api/<VerificationController>
        [HttpPost]
        public IActionResult Post([FromBody] VerificationDto dto,
            [FromServices] VerificationCommand command)
        {
             _executor.ExecuteCommand(command, dto);
             return StatusCode(204);
        }

    }
}
