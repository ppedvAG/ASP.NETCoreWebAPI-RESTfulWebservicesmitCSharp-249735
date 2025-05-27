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
        var exists = _context.Vehicles.SingleOrDefault(x => x.Id == id);
        if (exists != null)
        {
            _context.Vehicles.Remove(exists);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<bool> UpdateVehicle(Guid id, Auto vehicle)
    {
        var exists = _context.Vehicles.Any(x => x.Id == id);
        if (exists)
        {
            _context.Vehicles.Update(vehicle);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }
}
