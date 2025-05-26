using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace VehicleManagementApi.Models;

public class CreateVehicleDto
{
    // Validation Attribute um ModelState zu überprüfen
    [Required(ErrorMessage = "Hersteller muss angegeben werden")]
    [MaxLength(50)]
    public string Manufacturer { get; set; }

    [Required(ErrorMessage = "Modelname muss angegeben werden")]
    [MaxLength(50)]
    public string Model { get; set; }

    public string? Type { get; set; }

    public string? Fuel { get; set; }

    [Required, Range(45, 500)]
    public int TopSpeed { get; set; }

    public KnownColor Color { get; set; }

    [Required, DataType(DataType.Date)]
    public DateTime Registered { get; set; }
}
