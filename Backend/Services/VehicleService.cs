using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Models;

namespace Backend.Services
{
    public class VehicleService : IVehicleService
    {

        private readonly IVehicleRepository _vehicleRepo;

        public VehicleService(IVehicleRepository vehicleRepo)
        {
            _vehicleRepo = vehicleRepo;
        }

        public async Task AddAsync(Vehicle vehicle)
        {
            await _vehicleRepo.AddAsync(vehicle);
        }

        public async Task DeleteAync(Guid id)
        {
            var vehicle = await _vehicleRepo.GetVehicleAsync(id);
            await _vehicleRepo.DeleteAync(vehicle);
        }

        // Getting all vehicles to list
        public async Task<IEnumerable<Vehicle>> GetAllAsync()
        {
            var vehicles = await _vehicleRepo.GetAllAsync();
            return vehicles;
        }

        // Getting vehicles of current user
        public async Task<IEnumerable<Vehicle>> GetAsync(Guid id)
        {
            return await _vehicleRepo.GetAsync(id);
        }

        // Getting single vehicle by ID
        public async Task<Vehicle> GetVehicleAsync(Guid id)
        {
            return await _vehicleRepo.GetVehicleAsync(id);
        }

        public async Task UpdateAsync(Vehicle vehicle)
        {
            await _vehicleRepo.UpdateAsync(vehicle);
        }
    }
}
