using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DTOs
{
    public class OrderForForwarderDto
    {
        public Guid OrderId { get; set; }
        public Guid AdminId { get; set; }
        public Guid VehicleId { get; set; }
        public Guid LoadId { get; set; }
        public string LoadingAddress { get; set; }
        public string LoadingDate { get; set; }
        public string LoadingTime { get; set; }
        public string UnloadingAddress { get; set; }
        public string UnloadingDate { get; set; }
        public string UnloadingTime { get; set; }
        public string Type { get; set; }
        public double Latitude1 { get; set; }
        public double Longitude1 { get; set; }
        public double Latitude2 { get; set; }
        public double Longitude2 { get; set; }
        public string Status { get; set; }
        public string LoaderFirstName { get; set; }
        public string LoaderLastName { get; set; }
        public string TransportFirstName { get; set; }
        public string TransportLastName { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string ForwarderFirstName { get; set; }
        public string ForwarderLastName { get; set; }

    }
}
