using Backend.DTOs;
using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAsync(Guid id);
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order> GetOrderAsync(Guid id);
        Task<OrderForForwarderDto> GetOrderForwarderAsync(Guid id);
        Task<IEnumerable<OrderForForwarderDto>> GetAllOrderForwarder(Guid id);
        Task<IEnumerable<OrderForForwarderDto>> GetAllOrderTransport(Guid id);
        Task AddAsync(Order order);
        Task DeleteAync(Guid id);
        Task UpdateAsync(Order order);
    }
}
