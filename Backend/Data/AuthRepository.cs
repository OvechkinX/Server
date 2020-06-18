using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.DTOs;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApiContext _context;

        public AuthRepository(ApiContext context)
        {
            _context = context;
        }

        public async Task<User> Login(string username, string password)
        {
            string role = await userRole(username);
            if (role == null) return null;
            switch(role)
            {
                case "Admin":
                    var admin = await _context.Admins.FirstOrDefaultAsync(x => x.Username == username);

                    if (!VerifyPasswordhash(password, admin.PasswordHash, admin.PasswordSalt))
                        return null;

                    return admin;
                case "Loader":
                    var loader = await _context.Loaders.FirstOrDefaultAsync(x => x.Username == username);

                    if (!VerifyPasswordhash(password, loader.PasswordHash, loader.PasswordSalt))
                        return null;

                    return loader;
                case "Transport":
                    var transport = await _context.Transports.FirstOrDefaultAsync(x => x.Username == username);

                    if (!VerifyPasswordhash(password, transport.PasswordHash, transport.PasswordSalt))
                        return null;

                    return transport;
                default:
                    return null;
            }
        }

        private bool VerifyPasswordhash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i > computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                        return false;
                }
                return true;
            } 
        }

        public async Task Register(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);

            switch (userForRegisterDto.Role)
            {
                case "Admin":
                    var adminToCreate = new Admin(Guid.NewGuid(), userForRegisterDto.Role, userForRegisterDto.FirstName, passwordHash, passwordSalt,
                        userForRegisterDto.LastName, userForRegisterDto.Email, userForRegisterDto.Username);
                    await _context.Admins.AddAsync(adminToCreate);
                    break;
                case "Loader":
                    var loaderToCreate = new Loader(Guid.NewGuid(), userForRegisterDto.Role, userForRegisterDto.FirstName, passwordHash, passwordSalt,
                        userForRegisterDto.LastName, userForRegisterDto.Email, userForRegisterDto.Username);
                    await _context.Loaders.AddAsync(loaderToCreate);
                    break;
                case "Transport":
                    var transportToCreate = new Transport(Guid.NewGuid(), userForRegisterDto.Role, userForRegisterDto.FirstName, passwordHash, passwordSalt,
                        userForRegisterDto.LastName, userForRegisterDto.Email, userForRegisterDto.Username);
                    await _context.Transports.AddAsync(transportToCreate);
                    break;
            }

            await _context.SaveChangesAsync();
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> userExists(string username)
        {
            if (await _context.Admins.AnyAsync(x => x.Username == username))
                return true;
            if (await _context.Loaders.AnyAsync(x => x.Username == username))
                return true;
            if (await _context.Transports.AnyAsync(x => x.Username == username))
                return true;

            return false;
        }

        public async Task<string> userRole(string username)
        {
            if (await _context.Admins.AnyAsync(x => x.Username == username))
                return "Admin";
            if (await _context.Loaders.AnyAsync(x => x.Username == username))
                return "Loader";
            if (await _context.Transports.AnyAsync(x => x.Username == username))
                return "Transport";

            return null;
        }

    }
}
