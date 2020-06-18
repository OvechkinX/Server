using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Data
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<Vehicle>> GetAsync(Guid id);
        Task<IEnumerable<Vehicle>> GetAllAsync();
        Task<Vehicle> GetVehicleAsync(Guid id);
        Task AddAsync(Vehicle vehicle);
        Task UpdateAsync(Vehicle vehicle);
        Task DeleteAync(Vehicle vehicle);
    }
}
