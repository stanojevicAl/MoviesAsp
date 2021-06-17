using Application;
using Application.Searches;
using Implementation.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoggerController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public LoggerController(UseCaseExecutor executor)
        {
            _executor = executor;
        }
        [HttpGet]
        [Authorize]
        public IActionResult Get([FromQuery] LoggerSearch search,
            [FromServices] GetLoggetQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }
    }
}
