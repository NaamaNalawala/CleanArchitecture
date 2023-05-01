using RentalQuotationModule.Core.Entities;
using RentalQuotationModule.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalQuotationModule.Core.Services
{
        public class TodoService : ITodoService
        {
            private readonly IAsyncRepository<Todo> _repository;

            public TodoService(IAsyncRepository<Todo> repository)
            {
                _repository = repository;
            }

            public async Task<IEnumerable<Todo>> GetAllAsync()
            {
                return await _repository.GetAllAsync();
            }

            public async Task<Todo> GetByIdAsync(int id)
            {
                return await _repository.GetByIdAsync(id);
            }

            public async Task AddAsync(Todo entity)
            {
                await _repository.AddAsync(entity);
            }

            public async Task UpdateAsync(Todo entity)
            {
                await _repository.UpdateAsync(entity);
            }

            public async Task DeleteAsync(Todo entity)
            {
                await _repository.DeleteAsync(entity);
            }

    }
    }

