using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class UserRepository : IUserRepository
    {

        private readonly ApiContext _apiContext;

        public UserRepository(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        /*public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _apiContext.User.ToListAsync();
        }

        public async Task<User> GetUserAsync(Guid id)
        {
            return await _apiContext.User.SingleOrDefaultAsync(x => x.Id == id);
        }*/
    }
}
