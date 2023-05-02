using RentalQuotationModule.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalQuotationModule.Core.Interfaces
{
    public interface ICostComponentService
    {
        Task<IEnumerable<CostComponent>> GetAllAsync();
        Task<CostComponent> GetByIdAsync(int id);
        Task AddAsync(CostComponent entity);
        Task UpdateAsync(CostComponent entity);
        Task DeleteAsync(CostComponent entity);
    }
}
