using RentalQuotationModule.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalQuotationModule.Core.Interfaces
{
    public interface IQuotationService
    {
        Task<IEnumerable<Quotation>> GetAllAsync();
        Task<Quotation> GetByIdAsync(int id);
        Task AddAsync(Quotation entity);
        Task UpdateAsync(Quotation entity);
        Task DeleteAsync(Quotation entity);
    }
}
