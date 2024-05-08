using AutoMapper;
using TransportCargo.Application.Features.InstructionFeatures.Commands;
using TransportCargo.Application.Features.InstructionFeatures.Query;
using TransportCargo.Application.Features.TransportContainerFeatures.Commands;
using TransportCargo.Domain.Entities;

namespace TransportCargo.Application.Mapping
{
    public class AutoMappingConfig : Profile
    {
        public AutoMappingConfig()
        {
            CreateMap<CreateInstructionCommands, Instruction>().ReverseMap();
            CreateMap<InstructionViewModel, Instruction>().ReverseMap();
            CreateMap<CreateTransportContainerCommands, TransportContainer>().ReverseMap();
        }
    }
}
