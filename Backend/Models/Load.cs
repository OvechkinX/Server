using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Load
    {
        public Guid LoadId { get; set; }
        public string LoadingAddress { get; set; }
        public string LoadingDate { get; set; }
        public string LoadingTime { get; set; }
        public string UnloadingAddress { get; set; }
        public string UnloadingDate { get; set; }
        public string UnloadingTime { get; set; }
        public int Weight { get; set; }
        public int Volume { get; set; }
        public string Type { get; set; }
        public double Latitude1 { get; set; }
        public double Longitude1 { get; set; }
        public double Latitude2 { get; set; }
        public double Longitude2 { get; set; }
        public string Status { get; set; }
        public Guid LoaderId { get; set; }
        public virtual Loader Loader { get; set; }
        public virtual Order Order { get; set; }
    }
}
