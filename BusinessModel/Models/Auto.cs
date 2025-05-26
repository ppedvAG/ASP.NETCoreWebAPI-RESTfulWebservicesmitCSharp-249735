using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace BusinessModel.Models;

[PrimaryKey(nameof(Id))]
public class Auto
{
    [Key, Column("VehicleId")]
    public Guid Id { get; set; }

    [MaxLength(50)]
    public string Manufacturer { get; set; }

    [MaxLength(50)]
    public string Model { get; set; }

    public string Type { get; set; }

    public string Fuel { get; set; }

    public int TopSpeed { get; set; }

    public KnownColor Color { get; set; }

    public DateTime Registered { get; set; }
}
