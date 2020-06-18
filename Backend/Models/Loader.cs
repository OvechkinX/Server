using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Loader : User
    {
        public Loader(Guid id, string role, string firstName, byte[] passwordHash, byte[] passwordSalt,
            string lastName, string email, string username)
            : base(id, role, firstName, passwordHash, passwordSalt, lastName, email, username)
        {
        }
        public ICollection<Load> Loads { get; set; }
    }
}
