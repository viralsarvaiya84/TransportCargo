using Microsoft.AspNetCore.Mvc;
using TransportCargo.Application.Features.InstructionFeatures.Commands;
using TransportCargo.Application.Features.TransportContainerFeatures.Commands;
using TransportCargo.WebAPI.BaseController;

namespace TransportCargo.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TransportContainerController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateTransportContainerCommands createInstructionCommands)
        {
            return Ok(await Mediator.Send(createInstructionCommands));
        }
    }
}
