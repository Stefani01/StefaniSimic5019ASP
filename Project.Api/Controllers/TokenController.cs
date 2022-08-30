using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Api.Core;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {

        [HttpPost]
        public IActionResult Post([FromBody] TokenRequest request, [FromServices] JwtManager manager)
        {
            try
            {
                var token = manager.MakeToken(request.Username, request.Password);
                return Ok(new { token });
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
    public class TokenRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
