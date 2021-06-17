using Api.Core;
using DataAccess;
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
    public class TokenController : ControllerBase
    {
        private readonly JwtManager _manager;
        private readonly Context _context;

        public TokenController(JwtManager manager, Context context)
        {
            _manager = manager;
            _context = context;
        }

        // POST api/<TokenController>
        [HttpPost]
        public IActionResult Post([FromBody] LoginRequest request)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(x => x.Username == request.UserName && x.Password == request.Password && x.DeleteAt == null);

                if (user == null)
                {
                    return UnprocessableEntity("User with this username and password doesn't exist in database.");
                }

                if (user.Verification == false)
                {
                    return UnprocessableEntity("You must confirm registration to be able to log in");
                }
                var token = _manager.MakeToken(request.UserName, request.Password);

                if (token == null)
                {
                    return Unauthorized();
                }
                return Ok(new
                {
                    token
                });
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
    }

    public class LoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

