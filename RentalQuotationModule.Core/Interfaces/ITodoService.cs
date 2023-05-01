using RentalQuotationModule.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalQuotationModule.Core.Interfaces
{
    public interface ITodoService
    {
        Task<IEnumerable<Todo>> GetAllAsync();
        Task<Todo> GetByIdAsync(int id);
        Task AddAsync(Todo entity);
        Task UpdateAsync(Todo entity);
        Task DeleteAsync(Todo entity);
    }
}
