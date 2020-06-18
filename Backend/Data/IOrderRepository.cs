using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Data
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAsync(Guid id);
        Task<IEnumerable<Order>> GetAllAsync();
        Task<IEnumerable<Order>> GetAllForwarderOrders(Guid id);
        Task<Order> GetOrderAsync(Guid id);
        Task AddAsync(Order order);
        Task UpdateAsync(Order order);
        Task DeleteAync(Order order);
        Task<IEnumerable<Order>> GetAllTransportOrders(Guid id);
    }
}
