using Application;
using Application.DataTransfer;
using Application.Interfaces;
using DataAccess;
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
    public class RatingController : ControllerBase
    {
        private readonly IApplicationUser _user;
        private readonly UseCaseExecutor _executor;
        private readonly Context _context;

        public RatingController(IApplicationUser user, UseCaseExecutor executor, Context context)
        {
            _user = user;
            _executor = executor;
            _context = context;
        }
        // POST api/<RatingController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] RatingMovieDto dto,
            [FromServices] RatingMovieCommand command)
        {
            try
            {
                var movieRatin = _context.MovieRatings.FirstOrDefault(x => x.UserId == _user.Id && x.MovieId == dto.MoviedId);
                if (movieRatin != null)
                {
                    return UnprocessableEntity("You already rated this movie");
                }

                _executor.ExecuteCommand(command, dto);
                return StatusCode(201);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
    }
}
