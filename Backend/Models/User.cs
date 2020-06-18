using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models
{
    public abstract class User
    {
        protected User(Guid id, string role, string firstName, byte[] passwordHash, byte[] passwordSalt,
            string lastName, string email, string username)
        {
            Id = id;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            Role = role;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Username = username;
        }
        public Guid Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        
    }
}
