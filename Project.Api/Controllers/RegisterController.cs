using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Application.UseCases.Commands;
using Project.Application.UseCases.DTO;
using Project.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class RegisterController : ControllerBase
    {
        
        [HttpPost]
        public IActionResult Post([FromBody] UserRegisterDTO dto, [FromServices] UseCaseHandler handler, [FromServices] IUserRegistrationCommand command)
        {
            handler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

    }
}
