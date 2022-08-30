using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Application.UseCases.Commands;
using Project.Application.UseCases.DTO;
using Project.Application.UseCases.DTO.Search;
using Project.Application.UseCases.Queries;
using Project.Implementation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AlbumController : ControllerBase
    {
        public static IEnumerable<string> AllowedExtensions =>
            new List<string> { ".jpg", ".png", ".jpeg" };
        private UseCaseHandler _handler;
        public AlbumController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get([FromQuery] AlbumSearch search, [FromServices] IGetAlbumsQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult Get(int id, [FromServices] IGetAlbumByIdQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateAlbumDTO dto, [FromServices] ICreateAlbumCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        public IActionResult Put([FromBody] UpdateAlbumDTO dto, [FromServices] IUpdateAlbumCommand command)
        {
            _handler.HandleCommand(command, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteAlbumCommand command)
        {
            _handler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
