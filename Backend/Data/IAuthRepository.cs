using Backend.DTOs;
using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Data
{
    public interface IAuthRepository
    {

        Task Register(UserForRegisterDto userForRegisterDto);
        Task<User> Login(string username, string password);
        Task<bool> userExists(string username);

    }
}
