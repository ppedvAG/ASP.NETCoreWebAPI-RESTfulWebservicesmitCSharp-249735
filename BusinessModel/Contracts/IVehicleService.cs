using BusinessModel.Models;

namespace BusinessModel.Contracts
{
    public interface IVehicleService
    {
        Task AddVehicle(Auto vehicle);
        Task<bool> DeleteVehicle(Guid id);
        Task<Auto?> GetVehicleById(Guid id);
        Task<IEnumerable<Auto>> GetVehicles();
        Task<bool> UpdateVehicle(Guid id, Auto vehicle);
    }
}