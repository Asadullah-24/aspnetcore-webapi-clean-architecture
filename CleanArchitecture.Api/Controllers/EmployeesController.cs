using CleanArchitecture.Application.Commands;
using CleanArchitecture.Application.Queries;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Options;
using CleanArchitecture.Infrastructure.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CleanArchitecture.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    //IOptions is an example here to read value from appsettings.json file, you can inject any other service as well
    //public class EmployeesController(ISender sender, IOptions<ConnectionStringOptions> options) : ControllerBase

    public class EmployeesController : ControllerBase
    {
        private readonly ISender _sender;
        public EmployeesController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddEmployeeAsync([FromBody] EmployeeEntity employee)
        {
            var result = await _sender.Send(new AddEmployeeCommand(employee));
            return Ok(result);
        }

        [HttpGet("GetEmployees")]
        public async Task<IActionResult> GetAllEmployeesAsync()
        {
            var result = await _sender.Send(new GetAllEmployeesQuery());
            return Ok(result);

            //IOptions is an example here to read value from appsettings.json 
            //return Ok(options.Value.DefaultConnection);
        }

        [HttpGet("GetEmployeeById/{employeeId}")]
        public async Task<IActionResult> GetEmployeesByIdAsync([FromRoute] int employeeId)
        {
            var result = await _sender.Send(new GetEmployeeByIdQuery(employeeId));
            return Ok(result);
        }

        [HttpPut("UpdateEmployee/{employeeId}")]
        public async Task<IActionResult> UpdateEmployeeAsync([FromRoute] int employeeId, [FromBody] EmployeeEntity employee)
        {
            var result = await _sender.Send(new UpdateEmployeeCommand(employeeId, employee));
            return Ok(result);
        }

        [HttpDelete("DeleteEmployee/{employeeId}")]
        public async Task<IActionResult> DeleteEmployeeAsync([FromRoute] int employeeId)
        {
            var result = await _sender.Send(new DeleteEmployeeCommand(employeeId));
            return Ok(result);
        }
    }
}
