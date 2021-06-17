using Application;
using Application.DataTransfer;
using Application.Exceptions;
using Application.Interfaces;
using Application.Searches;
using DataAccess;
using Domain.Entities;
using Implementation.Commands.MovieCommands;
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
    public class FavoriteController : ControllerBase
    {
        private readonly IApplicationUser _user;
        private readonly UseCaseExecutor _executor;
        private readonly Context _context;

        public FavoriteController(IApplicationUser user, Context context, UseCaseExecutor executor)
        {
            _user = user;
            _context = context;
            _executor = executor;
        }

        // GET: api/<FavoriteController>
        [HttpGet]
        [Authorize]
        public IActionResult Get([FromQuery] CommonSearch search,
            [FromServices] GetFavoriteQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // POST api/<FavoriteController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] FavoriteMovieDto dto,
            [FromServices] FavoriteMovieCommand command)
        {
            if(dto == null)
            {
                return UnprocessableEntity("Movie is required");
            }
            try
            {
                var movie = _context.Movies.FirstOrDefault(x => x.Id == dto.MovieId && x.DeleteAt == null);
                if (movie == null)
                {
                    throw new EntityNotFoundException(typeof(Movie));
                }
                var movieUser = _context.UserFavorites
                    .FirstOrDefault(x => x.MovieId == dto.MovieId && x.UserId == _user.Id);
                if (movieUser != null)
                {
                    return UnprocessableEntity("Movie is already in favorites");
                }

                _executor.ExecuteCommand(command, dto);
                return StatusCode(204);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        // DELETE api/<UserController>
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id, [FromServices] DeleteFavoriteCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return StatusCode(204);
        }

    }
}
