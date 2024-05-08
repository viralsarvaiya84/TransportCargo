using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCargo.Application.Features.TransportContainerFeatures.Commands
{
    public class CreateTransportContainerCommandsValidation : AbstractValidator<CreateTransportContainerCommands>
    {
        public CreateTransportContainerCommandsValidation()
        {
            RuleFor(a => a.ClientRef).NotNull().NotEmpty();
            RuleFor(a => a.PickupAddress).NotNull().NotEmpty();
            RuleFor(a => a.DeliveryAddress).NotNull().NotEmpty();
            RuleFor(a => a.Transporter).NotNull().NotEmpty();
            RuleFor(a => a.VehicleReg).NotNull().NotEmpty();
            RuleFor(a => a.ContainerNumber).NotNull().NotEmpty();
            RuleFor(a => a.DateScheduled).GreaterThan(DateTime.MinValue);
            RuleFor(a => a.InstructionId).NotNull().GreaterThan(0);
            RuleFor(a => a.PickupDateTime).GreaterThan(DateTime.MinValue);
            RuleFor(a => a.DateTimeDelivered).GreaterThan(DateTime.MinValue);
        }
    }
}
