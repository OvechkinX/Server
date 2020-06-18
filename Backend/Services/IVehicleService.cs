using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services
{
    public interface IVehicleService
    {
        Task<IEnumerable<Vehicle>> GetAsync(Guid id);
        Task<IEnumerable<Vehicle>> GetAllAsync();
        Task<Vehicle> GetVehicleAsync(Guid id);
        Task AddAsync(Vehicle vehicle);
        Task DeleteAync(Guid id);
        Task UpdateAsync(Vehicle vehicle);
    }
}
