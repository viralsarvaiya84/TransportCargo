using AutoMapper;
using Azure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCargo.Application.Features.InstructionFeatures.Commands;
using TransportCargo.Application.Interface.Contract;
using TransportCargo.Application.Wrappers;
using TransportCargo.Domain.Entities;

namespace TransportCargo.Application.Features.InstructionFeatures.Query
{
    public class GetAllInstructionViewModelQuery:IRequest<PagedResponse<List<InstructionViewModel>>>
    {
    }

    public class GetAllInstructionViewModelQueryHandler : IRequestHandler<GetAllInstructionViewModelQuery, PagedResponse<List<InstructionViewModel>>>
    {
        private readonly IInstruction _instructionService;
        private readonly IMapper _mapper;
        public GetAllInstructionViewModelQueryHandler(IInstruction instructionService, IMapper mapper)
        {
            _instructionService = instructionService;
            _mapper = mapper;
        }
        public async Task<PagedResponse<List<InstructionViewModel>>> Handle(GetAllInstructionViewModelQuery command, CancellationToken cancellationToken)
        {
            try
            {
                
                var listOfInstruction =_instructionService.GetQueryableAsync().Where(a=>a.Status== "Pending").ToList();
                
                var listOfInstructionViewModel = _mapper.Map<List<InstructionViewModel>>(listOfInstruction);


                return new PagedResponse<List<InstructionViewModel>>(listOfInstructionViewModel,0,0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
