using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }
        [ForeignKey("Load")]
        public Guid LoadId { get; set; }
        public Guid VehicleId { get; set; }
        public Guid AdminId { get; set; }
        public string Status { get; set; }
        public virtual Admin Admin { get; set; }
        public virtual Load Load { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
