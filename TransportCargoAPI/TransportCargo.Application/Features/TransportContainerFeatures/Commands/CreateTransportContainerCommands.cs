using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TransportCargo.Application.Features.InstructionFeatures.Commands;
using TransportCargo.Application.Interface.Contract;
using TransportCargo.Domain.Entities;
using TransportCargo.Application.Wrappers;

namespace TransportCargo.Application.Features.TransportContainerFeatures.Commands
{
    public class CreateTransportContainerCommands : IRequest<Response<bool>>
    {
        public int InstructionId { get; set; }

        public string PickupAddress { get; set; }

        public string DeliveryAddress { get; set; }

        public string ClientRef { get; set; }

        public DateTime DateScheduled { get; set; }

        public string Transporter { get; set; }

        public string VehicleReg { get; set; }

        public string ContainerNumber { get; set; }

        public DateTime PickupDateTime { get; set; }

        public DateTime DateTimeDelivered { get; set; }
    }

    public class CreateTransportContainerCommandsHandler : IRequestHandler<CreateTransportContainerCommands, Response<bool>>
    {
        private readonly ITransportContainer _transportContainerService;
        private readonly IInstruction _instructionService;
        private readonly IMapper _mapper;
        public CreateTransportContainerCommandsHandler(ITransportContainer transportContainerService, IInstruction instruction, IMapper mapper)
        {
            _transportContainerService = transportContainerService;
            _instructionService = instruction;
            _mapper = mapper;
        }
        public async Task<Response<bool>> Handle(CreateTransportContainerCommands command, CancellationToken cancellationToken)
        {
            try
            {
                var container = _transportContainerService.GetQueryableAsync().Where(a => a.ContainerNumber == command.ContainerNumber).FirstOrDefault();
                if (container != null) 
                {
                  return  new Response<bool> 
                    {
                    Data = false,
                    Message= "Container Number Already Exist"
                    };
                }
                var getInstruction = _instructionService.GetQueryableAsync().FirstOrDefault(a => a.Id == command.InstructionId);
                getInstruction.Status = "Scheduled";
                
                var instruction = _mapper.Map<TransportContainer>(command);
                await _transportContainerService.AddAsync(instruction);
                await _instructionService.UpdateAsync(getInstruction);

                return new Response<bool>(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
