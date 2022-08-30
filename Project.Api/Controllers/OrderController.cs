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
    public class OrderController : ControllerBase
    {
        private UseCaseHandler _handler;
        public OrderController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        // POST api/<OrderController>
        [HttpPost]
        public IActionResult Post([FromBody] OrderDTO dto, [FromServices] ICreateOrderCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteOrderCommand command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
