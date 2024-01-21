using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie_App.Search.Command;
using Movie_App.Search.Query;

namespace Movie_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LatestSearchController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LatestSearchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("save-latest-searches")]
        public async Task<IActionResult> SaveLatestSearch([FromBody] SaveLatestSearchCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("get-latest-searches")]
        public async Task<IActionResult> GetLatestSearches()
        {
            var query = new GetLatestSearchesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
