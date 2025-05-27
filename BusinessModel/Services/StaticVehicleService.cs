using BusinessModel.Contracts;
using BusinessModel.Data;
using BusinessModel.Models;

namespace BusinessModel.Services;

public class StaticVehicleService : IVehicleService
{
    private readonly List<Auto> _autos = Seed.GenerateAutos(20).ToList();

    public Task<IEnumerable<Auto>> GetVehicles()
    {
        return Task.FromResult(_autos.AsEnumerable());
    }

    public Task<Auto?> GetVehicleById(Guid id)
    {
        var result = _autos.SingleOrDefault(x => x.Id == id);
        return Task.FromResult(result);
    }

    public Task AddVehicle(Auto vehicle)
    {
        vehicle.Id = Guid.NewGuid();
        _autos.Add(vehicle);
        return Task.CompletedTask;
    }

    public Task<bool> DeleteVehicle(Guid id)
    {
        var index = _autos.FindIndex(x => x.Id == id);
        if (index != -1)
        {
            _autos.RemoveAt(index);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }

    public Task<bool> UpdateVehicle(Guid id, Auto vehicle)
    {
        var index = _autos.FindIndex(x => x.Id == id);
        if (index != -1)
        {
            _autos[index] = vehicle;
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }
}
