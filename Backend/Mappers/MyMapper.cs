using Backend.Data;
using Backend.DTOs;
using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Mappers
{
    public static class MyMapper
    {
        public static OrderForForwarderDto GetOrderForwarder(Order order)
        {
            var orderForForwarderDto = new OrderForForwarderDto
            {
                OrderId = order.OrderId,
                AdminId = order.AdminId,
                VehicleId = order.VehicleId,
                LoadId = order.LoadId,
                LoadingAddress = order.Load.LoadingAddress,
                LoadingDate = order.Load.LoadingDate,
                LoadingTime = order.Load.LoadingTime,
                UnloadingAddress = order.Load.UnloadingAddress,
                UnloadingDate = order.Load.UnloadingDate,
                UnloadingTime = order.Load.UnloadingTime,
                Type = order.Load.Type,
                Latitude1 = order.Load.Latitude1,
                Latitude2 = order.Load.Latitude2,
                Longitude1 = order.Load.Longitude1,
                Longitude2 = order.Load.Longitude2,
                Status = order.Status,
                LoaderFirstName = order.Load.Loader.FirstName,
                LoaderLastName = order.Load.Loader.LastName,
                TransportFirstName = order.Vehicle.Transport.FirstName,
                TransportLastName = order.Vehicle.Transport.LastName,
                Brand = order.Vehicle.Brand,
                Model = order.Vehicle.Model,
                ForwarderFirstName = order.Admin.FirstName,
                ForwarderLastName = order.Admin.LastName
            };


            return orderForForwarderDto;
        }

        public static IEnumerable<OrderForForwarderDto> GetOrderForwarder(IEnumerable<Order> orders)
        {

            List<OrderForForwarderDto> ordersForForwarderDto = new List<OrderForForwarderDto>();

            foreach (var item in orders)
            {
                var orderForForwarderDto = new OrderForForwarderDto
                {
                    OrderId = item.OrderId,
                    AdminId = item.AdminId,
                    VehicleId = item.VehicleId,
                    LoadId = item.LoadId,
                    LoadingAddress = item.Load.LoadingAddress,
                    LoadingDate = item.Load.LoadingDate,
                    LoadingTime = item.Load.LoadingTime,
                    UnloadingAddress = item.Load.UnloadingAddress,
                    UnloadingDate = item.Load.UnloadingDate,
                    UnloadingTime = item.Load.UnloadingTime,
                    Type = item.Load.Type,
                    Latitude1 = item.Load.Latitude1,
                    Latitude2 = item.Load.Latitude2,
                    Longitude1 = item.Load.Longitude1,
                    Longitude2 = item.Load.Longitude2,
                    Status = item.Status,
                    LoaderFirstName = item.Load.Loader.FirstName,
                    LoaderLastName = item.Load.Loader.LastName,
                    TransportFirstName = item.Vehicle.Transport.FirstName,
                    TransportLastName = item.Vehicle.Transport.LastName,
                    Brand = item.Vehicle.Brand,
                    Model = item.Vehicle.Model,
                    ForwarderFirstName = item.Admin.FirstName,
                    ForwarderLastName = item.Admin.LastName
                };

                ordersForForwarderDto.Add(orderForForwarderDto);
            }



            return ordersForForwarderDto;
        }
    }
}
