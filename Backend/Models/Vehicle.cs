using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Vehicle
    {
        public Guid VehicleId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Registration { get; set; }
        public string Type { get; set; }
        public int Weight { get; set; }
        public int Volume { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public string Status { get; set; }
        public Guid TransportId { get; set; }
        public virtual Transport Transport { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
