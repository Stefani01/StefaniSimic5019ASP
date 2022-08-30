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
    [Authorize]
    public class LikeController : ControllerBase
    {
        private UseCaseHandler _handler;
        public LikeController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public IActionResult Post([FromBody] LikeDTO dto, [FromServices] ICreateLikeCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] LikeDTO dto, [FromServices] IDeleteLikeCommand command)
        {
            _handler.HandleCommand(command, dto);
            return NoContent();
        }
    }
}
