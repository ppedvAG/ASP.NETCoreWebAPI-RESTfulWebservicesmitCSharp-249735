using BusinessModel.Models;
using VehicleManagementApi.Models;

namespace VehicleManagementApi.Mappers;

/// <summary>
/// Mapper welche sog. Extension Methoden verwendet.
/// </summary>
/// <remarks>
/// Alternative: Install-Package AutoMapper
/// Mapping wird dann zur Laufzeit durchgeführt.
/// Kritikpunkte: 
/// - Verlust der Kontrolle 
/// - Fail-Fast ist nicht mehr gegeben
/// - Steigende Komplexität bei Transformation von Eigenschaften
/// </remarks>
public static class VehiclesMapper
{
    public static VehicleResultDto ToDto(this Auto vehicle)
    {
        return new VehicleResultDto
        {
            Id = vehicle.Id,
            Manufacturer = vehicle.Manufacturer,
            Model = vehicle.Model,
            Type = vehicle.Type,
            Fuel = vehicle.Fuel,
            TopSpeed = vehicle.TopSpeed,
            Registered = vehicle.Registered.ToLongDateString(),
            Color = vehicle.Color,
            ColorAsString = vehicle.Color.ToString()
        };
    }

    public static Auto ToEntity(this CreateVehicleDto vehicle)
    {
        return new Auto
        {
            Manufacturer = vehicle.Manufacturer,
            Model = vehicle.Model,
            Type = vehicle.Type,
            Fuel = vehicle.Fuel,
            TopSpeed = vehicle.TopSpeed,
            Registered = vehicle.Registered,
            Color = vehicle.Color
        };
    }
}
