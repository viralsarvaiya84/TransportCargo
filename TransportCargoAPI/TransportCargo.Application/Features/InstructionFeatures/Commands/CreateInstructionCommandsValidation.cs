using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCargo.Domain.Enums;

namespace TransportCargo.Application.Features.InstructionFeatures.Commands
{
    public class CreateInstructionCommandsValidation: AbstractValidator<CreateInstructionCommands>
    {
        public CreateInstructionCommandsValidation() 
        {
            RuleFor(a => a.InstructionDate).GreaterThan(DateTime.MinValue);
            RuleFor(a => a.ClientName).NotNull().NotEmpty();
            RuleFor(a => a.PickupAddress).NotNull().NotEmpty();
            RuleFor(a => a.DeliveryAddress).NotNull().NotEmpty();
            RuleFor(a => a.ClientRef).NotNull().NotEmpty();
            RuleFor(a => a.BookingRef).NotNull().NotEmpty();
            RuleFor(a => a.Status).IsEnumName(typeof(StatusEnum));
            RuleFor(a => a.Qty).GreaterThan(0);
        }
    }
}
