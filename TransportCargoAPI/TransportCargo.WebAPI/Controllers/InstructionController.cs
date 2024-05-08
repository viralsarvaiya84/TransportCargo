using Microsoft.AspNetCore.Mvc;
using TransportCargo.Application.Features.InstructionFeatures.Commands;
using TransportCargo.Application.Features.InstructionFeatures.Query;
using TransportCargo.WebAPI.BaseController;

namespace TransportCargo.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class InstructionController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateInstructionCommands createInstructionCommands)
        {
            return Ok(await Mediator.Send(createInstructionCommands));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetAllInstructionViewModelQuery()));
        }
    }
}
