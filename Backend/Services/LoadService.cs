using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Models;

namespace Backend.Services
{
    public class LoadService : ILoadService
    {
        private readonly ILoadRepository _loadRepo;

        public LoadService(ILoadRepository load)
        {
            _loadRepo = load;
        }

        public async Task AddAsync(Load load)
        {
            await _loadRepo.AddAsync(load);
        }

        public async Task DeleteAync(Guid id)
        {
            var load = await _loadRepo.GetLoadAsync(id);
            await _loadRepo.DeleteAync(load);
        }

        //Getting all loads to list
        public async Task<IEnumerable<Load>> GetAllAsync()
        {
            var loads = await _loadRepo.GetAllAsync();
            return loads;
        }
        
        //Getting loads of current user
        public async Task<IEnumerable<Load>> GetAsync(Guid id)
        {
            return await _loadRepo.GetAsync(id);
        }

        //Getting single load by ID
        public async Task<Load> GetLoadAsync(Guid id)
        {
            return await _loadRepo.GetLoadAsync(id);
        }

        public async Task UpdateAsync(Load load)
        {
            await _loadRepo.UpdateAsync(load);
        }
    }
}
