using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Backend.Data
{
    public class VehicleRepository : IVehicleRepository
    {

        private readonly ApiContext _apiContext;

        public VehicleRepository(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        public async Task AddAsync(Vehicle vehicle)
        {
            await _apiContext.Vehicle.AddAsync(vehicle);
            await _apiContext.SaveChangesAsync();
        }

        public async Task DeleteAync(Vehicle vehicle)
        {
            _apiContext.Vehicle.Remove(vehicle);
            await _apiContext.SaveChangesAsync();
        }

        // Getting all Vehicle to list
        public async Task<IEnumerable<Vehicle>> GetAllAsync()
        {
            return await _apiContext.Vehicle.Where(x => x.Status == "Dostępny").ToListAsync();
        }

        // Getting current user vehicles
        public async Task<IEnumerable<Vehicle>> GetAsync(Guid id)
        {
            return await _apiContext.Vehicle.Where(x => x.TransportId == id).ToListAsync();
        }

        // Getting single vehicle by ID
        public async Task<Vehicle> GetVehicleAsync(Guid id)
        {
            return await _apiContext.Vehicle.SingleOrDefaultAsync(x => x.VehicleId == id);
        }

        public async Task UpdateAsync(Vehicle vehicle)
        {
            _apiContext.Vehicle.Update(vehicle);
            await _apiContext.SaveChangesAsync();
        }
    }
}
