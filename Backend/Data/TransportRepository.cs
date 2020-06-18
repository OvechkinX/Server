using Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Data
{
    public class TransportRepository : ITransportRepository
    {
        private readonly ApiContext _apiContext;

        public TransportRepository(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        public async Task<Transport> GetTransportAsync(Guid id)
        {
            return await _apiContext.Transports.SingleOrDefaultAsync(x => x.Id == id);
        }


    }
}
