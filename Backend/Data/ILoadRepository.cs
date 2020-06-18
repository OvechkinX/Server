using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Data
{
    public interface ILoadRepository
    {
        Task<IEnumerable<Load>> GetAsync(Guid id);
        Task<IEnumerable<Load>> GetAllAsync();
        Task<Load> GetLoadAsync(Guid id);
        Task AddAsync(Load load);
        Task UpdateAsync(Load load);
        Task DeleteAync(Load load);
    }
}
