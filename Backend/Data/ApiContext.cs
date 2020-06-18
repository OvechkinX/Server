using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models
{
    public class ApiContext : DbContext
    {
        public ApiContext (DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Loader> Loaders { get; set; }
        public DbSet<Transport> Transports { get; set; }
        public DbSet<Load> Load { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<Order> Order { get; set; }
    }
}
