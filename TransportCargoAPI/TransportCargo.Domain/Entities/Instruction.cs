using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TransportCargo.Domain.Entities;

[Table("Instruction")]
public partial class Instruction
{
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime InstructionDate { get; set; }

    [StringLength(250)]
    public string ClientName { get; set; } = null!;

    [StringLength(1000)]
    public string PickupAddress { get; set; } = null!;

    [StringLength(1000)]
    public string DeliveryAddress { get; set; } = null!;

    [StringLength(250)]
    public string ClientRef { get; set; } = null!;

    [StringLength(100)]
    public string BookingRef { get; set; } = null!;

    [StringLength(100)]
    public string Status { get; set; } = null!;

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Qty { get; set; }

    [InverseProperty("Instruction")]
    public virtual ICollection<TransportContainer> TransportContainers { get; set; } = new List<TransportContainer>();
}
