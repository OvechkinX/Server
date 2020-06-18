using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class OrderRepository : IOrderRepository
    {

        private readonly ApiContext _apiContext;

        public OrderRepository(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        public async Task AddAsync(Order order)
        {
            await _apiContext.Order.AddAsync(order);
            await _apiContext.SaveChangesAsync();
        }

        public async Task DeleteAync(Order order)
        {
            _apiContext.Order.Remove(order);
            await _apiContext.SaveChangesAsync();
        }

        // Gets All Rows From Order Table
        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _apiContext.Order.ToListAsync();
        }

        // Gets All Rows From Joined Tables for current Forwarder
        public async Task<IEnumerable<Order>> GetAllForwarderOrders(Guid id)
        {
            return await _apiContext.Order.Include(x => x.Load).ThenInclude(x => x.Loader)
                .Include(x => x.Vehicle).ThenInclude(x => x.Transport).Include(x => x.Admin)
                .Where(x => x.AdminId == id).ToListAsync();
        }

        // Gets All Rows From Joined Table for Current Transports
        public async Task<IEnumerable<Order>> GetAllTransportOrders(Guid id)
        {
            return await _apiContext.Order.Include(x => x.Load).ThenInclude(x => x.Loader)
                .Include(x => x.Vehicle).ThenInclude(x => x.Transport).Include(x => x.Admin)
                .Where(x => x.Vehicle.TransportId == id).ToListAsync();
        }

        // Gets All Rows From Order Table for current Forwarder
        public async Task<IEnumerable<Order>> GetAsync(Guid id)
        {
            return await _apiContext.Order.Where(x => x.AdminId == id).ToListAsync();
        }

        //Gets Single Row From Joined Tables for OrderId
        public async Task<Order> GetOrderAsync(Guid id)
        {
            return await _apiContext.Order.Include(x => x.Load).ThenInclude(x => x.Loader)
                .Include(x => x.Vehicle).ThenInclude(x => x.Transport).Include(x => x.Admin)
                .SingleOrDefaultAsync(x => x.OrderId == id);
        }

        public async Task UpdateAsync(Order order)
        {
            _apiContext.Order.Update(order);
            await _apiContext.SaveChangesAsync();
        }
    }
}
