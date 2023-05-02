using RentalQuotationModule.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalQuotationModule.Core.Interfaces
{
    public interface ICostDetailService
    {
        Task<IEnumerable<CostDetails>> GetAllAsync();
        Task<CostDetails> GetByIdAsync(int id);
        Task AddAsync(CostDetails entity);
        Task UpdateAsync(CostDetails entity);
        Task DeleteAsync(CostDetails entity);
    }
}
