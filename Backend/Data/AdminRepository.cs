using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class AdminRepository : IAdminRepository
    {

        private readonly ApiContext _apiContext;

        public AdminRepository(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        public async Task<Admin> GetAdminAsync(Guid id)
        {
            return await _apiContext.Admins.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
