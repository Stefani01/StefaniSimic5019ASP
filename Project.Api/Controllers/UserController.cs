using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Application.UseCases.Commands;
using Project.Application.UseCases.Commands.User;
using Project.Application.UseCases.DTO;
using Project.Application.UseCases.DTO.Search;
using Project.Application.UseCases.Queries.User;
using Project.Domen;
using Project.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private UseCaseHandler _handler;
        public UserController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] BasePaginationSearch search, [FromServices] IGetUsersQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetUserByIdQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] UseCaseDTO dto,[FromServices] ICreateUserUseCasesCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        public IActionResult Put([FromBody] UseCaseDTO dto, [FromServices] IUpdateUserUseCasesCommand command)
        {
            _handler.HandleCommand(command, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteUserCommand command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
