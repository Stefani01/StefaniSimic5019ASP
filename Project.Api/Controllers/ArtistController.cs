using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Application.UseCases.Commands;
using Project.Application.UseCases.DTO;
using Project.Application.UseCases.DTO.Search;
using Project.Application.UseCases.Queries;
using Project.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ArtistController : ControllerBase
    {
        private UseCaseHandler _handler;
        public ArtistController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromQuery] BasePaginationSearch search, [FromServices] IGetArtistsQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult Get(int id, [FromServices] IGetArtistByIdQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateArtistDTO dto, [FromServices] ICreateArtistCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        public IActionResult Put([FromBody] UpdateArtistDTO dto, [FromServices] IUpdateArtistCommand command)
        {
            _handler.HandleCommand(command, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteArtistCommand command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
