using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services
{
    public interface ILoadService
    {
        Task<IEnumerable<Load>> GetAsync(Guid id);
        Task<IEnumerable<Load>> GetAllAsync();
        Task<Load> GetLoadAsync(Guid id);
        Task AddAsync(Load load);      
        Task DeleteAync(Guid id);
        Task UpdateAsync(Load load);
    }
}
