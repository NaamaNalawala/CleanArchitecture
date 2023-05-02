using RentalQuotationModule.Core.Entities;
using RentalQuotationModule.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentalQuotationModule.Core.Services
{
    public class CostDetailService : ICostDetailService
    {
        private readonly IAsyncRepository<CostDetails> _repository;

        public CostDetailService(IAsyncRepository<CostDetails> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CostDetails>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<CostDetails> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(CostDetails entity)
        {
            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(CostDetails entity)
        {
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(CostDetails entity)
        {
            await _repository.DeleteAsync(entity);
        }

    }
}
