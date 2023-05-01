using Microsoft.EntityFrameworkCore;
using RentalQuotationModule.Core.Entities;
using RentalQuotationModule.Core.Interfaces;
using RentalQuotationModule.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalQuotationModule.Infrastructure.Repositories
{
    public class EfRepository<T> : IAsyncRepository<T> where T : BaseEntity
    {
        private readonly RentalQuotationContext _dbContext;

        public EfRepository(RentalQuotationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
