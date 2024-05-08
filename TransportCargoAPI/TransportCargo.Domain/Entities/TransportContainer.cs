using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TransportCargo.Domain.Entities;

[Table("TransportContainer")]
public partial class TransportContainer
{
    [Key]
    public int TransportContainerId { get; set; }

    [Column("InstructionID")]
    public int InstructionId { get; set; }

    [StringLength(1000)]
    public string PickupAddress { get; set; } = null!;

    [StringLength(1000)]
    public string DeliveryAddress { get; set; } = null!;

    [StringLength(250)]
    public string ClientRef { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime DateScheduled { get; set; }

    [StringLength(500)]
    public string Transporter { get; set; } = null!;

    [StringLength(100)]
    public string VehicleReg { get; set; } = null!;

    [StringLength(100)]
    public string ContainerNumber { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime PickupDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DateTimeDelivered { get; set; }

    [ForeignKey("InstructionId")]
    [InverseProperty("TransportContainers")]
    public virtual Instruction Instruction { get; set; } = null!;
}
