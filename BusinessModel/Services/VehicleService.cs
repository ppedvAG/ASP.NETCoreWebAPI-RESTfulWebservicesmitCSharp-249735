using BusinessModel.Contracts;
using BusinessModel.Data;
using BusinessModel.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessModel.Services;

public class VehicleService : IVehicleService
{
    private readonly VehicleDbContext _context;

    public VehicleService(VehicleDbContext context)
    {
        _context = context;
    }

    public async Task<Auto?> GetVehicleById(Guid id)
        => await _context.Vehicles.SingleOrDefaultAsync(x => x.Id == id);

    public async Task<IEnumerable<Auto>> GetVehicles()
        => await _context.Vehicles.ToListAsync();

    public async Task AddVehicle(Auto vehicle)
    {
        _context.Vehicles.Add(vehicle);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteVehicle(Guid id)
    {
        var existingVehicle = _context.Vehicles.SingleOrDefault(x => x.Id == id);
        if (existingVehicle != null)
        {
            _context.Vehicles.Remove(existingVehicle);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<bool> UpdateVehicle(Guid id, Auto vehicle)
    {
        var existingVehicle = _context.Vehicles.SingleOrDefault(x => x.Id == id);
        if (existingVehicle != null)
        {
            existingVehicle.Manufacturer = vehicle.Manufacturer;
            existingVehicle.Model = vehicle.Model;
            existingVehicle.Type = vehicle.Type;
            existingVehicle.Registered = vehicle.Registered;

            existingVehicle.Color = vehicle.Color;
            existingVehicle.TopSpeed = vehicle.TopSpeed;
            existingVehicle.Fuel = vehicle.Fuel;

            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }
}
