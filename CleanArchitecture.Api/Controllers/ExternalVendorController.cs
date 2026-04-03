using CleanArchitecture.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalVendorController(ISender sender) : ControllerBase
    {

        [HttpGet("GetTypicodeUsers")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var result = await sender.Send(new GetTypicodeDataQuery());
            return Ok(result);

        }

        [HttpGet("GetPostById/{postId}")]
        public async Task<IActionResult> GetPostByIdAsync([FromRoute] int postId)
        {
            var result = await sender.Send(new GetTypicodePostByIdQuery(postId));
            return Ok(result);
        }
    }
}
