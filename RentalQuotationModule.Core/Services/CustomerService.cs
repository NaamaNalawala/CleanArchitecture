using RentalQuotationModule.Core.Entities;
using RentalQuotationModule.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentalQuotationModule.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IAsyncRepository<Customer> _repository;

        public CustomerService(IAsyncRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Customer entity)
        {
            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(Customer entity)
        {
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(Customer entity)
        {
            await _repository.DeleteAsync(entity);
        }

    }
}
