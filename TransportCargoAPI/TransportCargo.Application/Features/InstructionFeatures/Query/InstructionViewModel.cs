
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TransportCargo.Application.Features.InstructionFeatures.Query
{
    public class InstructionViewModel
    {
        public int Id { get; set; }

        public DateTime InstructionDate { get; set; }

        public string ClientName { get; set; } = null!;

        public string PickupAddress { get; set; } = null!;

        public string DeliveryAddress { get; set; } = null!;

        public string ClientRef { get; set; } = null!;

        public string BookingRef { get; set; } = null!;

        public string Status { get; set; } = null!;

        public decimal Qty { get; set; }
    }
}
