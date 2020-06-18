using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class LoadRepository : ILoadRepository
    {
        private readonly ApiContext _apiContext;

        public LoadRepository(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        public async Task AddAsync(Load load)
        {
            await _apiContext.Load.AddAsync(load);
            await _apiContext.SaveChangesAsync();
        }

        public async Task DeleteAync(Load load)
        {
            _apiContext.Load.Remove(load);
            await _apiContext.SaveChangesAsync();
        }

        // Getting all Loads to list
        public async Task<IEnumerable<Load>> GetAllAsync()
        {
            return await _apiContext.Load.Where(x => x.Status == "Oczekuje").ToListAsync();
        }

        // Getting current user loads
        public async Task<IEnumerable<Load>> GetAsync(Guid id)
        {
            
            return await _apiContext.Load.Where(x => x.LoaderId == id).ToListAsync();
        }

        //Getting single load by ID
        public async Task<Load> GetLoadAsync(Guid id)
        {
            return await _apiContext.Load.SingleOrDefaultAsync(x => x.LoadId == id);
        }

        public async Task UpdateAsync(Load load)
        {
            _apiContext.Load.Update(load);
            await _apiContext.SaveChangesAsync();
        }
    }
}
