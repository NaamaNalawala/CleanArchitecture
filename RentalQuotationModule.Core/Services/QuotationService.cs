using RentalQuotationModule.Core.Entities;
using RentalQuotationModule.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalQuotationModule.Core.Services
{
    public class QuotationService : IQuotationService
    {
        private readonly IAsyncRepository<Quotation> _repository;

        public QuotationService(IAsyncRepository<Quotation> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Quotation>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Quotation> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Quotation entity)
        {
            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(Quotation entity)
        {
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(Quotation entity)
        {
            await _repository.DeleteAsync(entity);
        }

    }
}
