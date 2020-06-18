using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class LoaderRepository : ILoaderRepository
    {
        private readonly ApiContext _apiContext;

        public LoaderRepository(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        public async Task<Loader> GetLoaderAsync(Guid id)
        {
            return await _apiContext.Loaders.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
