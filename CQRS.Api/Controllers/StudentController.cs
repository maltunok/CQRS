using CQRS.Application.Commands;
using CQRS.Application.Models;
using CQRS.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<StudentDto>> CreateStudent([FromBody] CreateStudentCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        public async Task<ActionResult<ICollection<StudentDto>>> GetAllStudentsByAge([FromQuery] GetStudentsByAgeQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}
