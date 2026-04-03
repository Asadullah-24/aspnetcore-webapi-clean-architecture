using CleanArchitecture.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace CleanArchitecture.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JsonDummyController : ControllerBase
    {
        private readonly ISender _sender;
        public JsonDummyController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("GetJsonDummyData")]
        public async Task<IActionResult> GetAllJsonDataAsync()
        {
            var result = await _sender.Send(new GetAllJsonDataQuery());
            return Ok(result);

        }
    }
}
