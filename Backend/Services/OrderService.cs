using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.DTOs;
using Backend.Mappers;
using Backend.Models;

namespace Backend.Services
{
    public class OrderService : IOrderService
    {

        private readonly IOrderRepository _orderRepo;
        private readonly ILoadRepository _loadRepo;
        private readonly IVehicleRepository _vehicleRepo;
        private readonly ILoaderRepository _loaderRepo;
        private readonly ITransportRepository _transportRepo;

        public OrderService(IOrderRepository orderRepo, ILoadRepository loadRepo,
            IVehicleRepository vehicleRepo,
            ILoaderRepository loaderRepo, ITransportRepository transportRepo)
        {
            _orderRepo = orderRepo;
            _loadRepo = loadRepo;
            _vehicleRepo = vehicleRepo;
            _loaderRepo = loaderRepo;
            _transportRepo = transportRepo;
        }

        public async Task AddAsync(Order order)
        {
            await _orderRepo.AddAsync(order);

            var load = await _loadRepo.GetLoadAsync(order.LoadId);
            var vehicle = await _vehicleRepo.GetVehicleAsync(order.VehicleId);

            load.Status = "W Trakcie";
            vehicle.Status = "Niedostępny";

            await _loadRepo.UpdateAsync(load);
            await _vehicleRepo.UpdateAsync(vehicle);
        }

        public async Task DeleteAync(Guid id)
        {
            var order = await _orderRepo.GetOrderAsync(id);
            await _orderRepo.DeleteAync(order);
        }

        // Gets All Rows From Order Table
        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            var orders = await _orderRepo.GetAllAsync();
            return orders;
        }
        // Gets All Rows From Joined Tables for current Forwarder
        public async Task<IEnumerable<OrderForForwarderDto>> GetAllOrderForwarder(Guid id)
        {
            var orders = await _orderRepo.GetAllForwarderOrders(id);
            return MyMapper.GetOrderForwarder(orders);
        }

        public async Task<IEnumerable<OrderForForwarderDto>> GetAllOrderTransport(Guid id)
        {
            var orders = await _orderRepo.GetAllTransportOrders(id);
            return MyMapper.GetOrderForwarder(orders);
        }

        // Gets All Rows From Order Table for current Forwarder
        public async Task<IEnumerable<Order>> GetAsync(Guid id)
        {
            return await _orderRepo.GetAsync(id);
        }

        // Gets Single Row From Order Table
        public async Task<Order> GetOrderAsync(Guid id)
        {
            return await _orderRepo.GetOrderAsync(id);

        }

        //Gets Single Row From Joined Tables for OrderId
        public async Task<OrderForForwarderDto> GetOrderForwarderAsync(Guid id)
        {
            var order = await _orderRepo.GetOrderAsync(id);
            return MyMapper.GetOrderForwarder(order);
        }

        public async Task UpdateAsync(Order order)
        {
            var load = await _loadRepo.GetLoadAsync(order.LoadId);
            var vehicle = await _vehicleRepo.GetVehicleAsync(order.VehicleId);

            if(order.Status == "Zrealizowano")
            {
                load.Status = "Zrealizowano";
                vehicle.Status = "Dostępny";
            }

            await _orderRepo.UpdateAsync(order);
            await _loadRepo.UpdateAsync(load);
            await _vehicleRepo.UpdateAsync(vehicle);
        }
    }
}
