using RentalQuotationModule.Core.Entities;
using RentalQuotationModule.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentalQuotationModule.Core.Services
{
    public class CostComponentService : ICostComponentService
    {
        private readonly IAsyncRepository<CostComponent> _repository;

        public CostComponentService(IAsyncRepository<CostComponent> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CostComponent>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<CostComponent> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(CostComponent entity)
        {
            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(CostComponent entity)
        {
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(CostComponent entity)
        {
            await _repository.DeleteAsync(entity);
        }


    }
}
