using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nilvera.Application.Features.Firma.Commands;
using Nilvera.Application.Features.Firma.Queries;
using System.Threading.Tasks;

namespace Nilvera.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FirmaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FirmaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFirma([FromBody] CreateFirmaCommand command)
        {
            if (command == null)
                return BadRequest();

            var result = await _mediator.Send(command);
            return Ok(new { FirmaId = result });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetFirmaByIdQuery(id));
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFirma(int id, [FromBody] UpdateFirmaCommand command)
        {
            if (command == null || id != command.Id)
                return BadRequest();

            var result = await _mediator.Send(command);
            return result > 0 ? Ok(result) : BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFirma(int id)
        {
            var result = await _mediator.Send(new DeleteFirmaCommand(id));
            return result > 0 ? NoContent() : NotFound();
        }
    }
}
