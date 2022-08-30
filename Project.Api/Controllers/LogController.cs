using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Application.UseCases.DTO.Search;
using Project.Application.UseCases.Queries;
using Project.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LogController : ControllerBase
    {
        // GET: api/<LogController>
        [HttpGet]
        public IActionResult Get([FromQuery] UseCaseLogSearch search, [FromServices] ISearchLogQuery query, [FromServices] UseCaseHandler handler)
        {
            return Ok(handler.HandleQuery(query, search));
        }

    }
}
