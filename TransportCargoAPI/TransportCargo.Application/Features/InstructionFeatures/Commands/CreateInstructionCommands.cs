using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCargo.Application.Wrappers;
using TransportCargo.Application.Interface.Contract;
using AutoMapper;
using TransportCargo.Domain.Entities;

namespace TransportCargo.Application.Features.InstructionFeatures.Commands
{
    public class CreateInstructionCommands : IRequest<Response<bool>>
    {
        public DateTime InstructionDate { get; set; }

        public string ClientName { get; set; }

        public string PickupAddress { get; set; }

        public string DeliveryAddress { get; set; }

        public string ClientRef { get; set; }

        public string BookingRef { get; set; }

        public string Status { get; set; }

        public decimal Qty { get; set; }

    }
    public class CreateInstructionCommandsHandler : IRequestHandler<CreateInstructionCommands, Response<bool>>
    {
        private readonly IInstruction _instructionService;
        private readonly IMapper _mapper;
        public CreateInstructionCommandsHandler(IInstruction instructionService, IMapper mapper)
        {
            _instructionService = instructionService;
            _mapper = mapper;
        }
        public async Task<Response<bool>> Handle(CreateInstructionCommands command, CancellationToken cancellationToken)
        {
            try
            {
                var instruction = _mapper.Map<Instruction>(command);
                await _instructionService.AddAsync(instruction);

                return new Response<bool>(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
