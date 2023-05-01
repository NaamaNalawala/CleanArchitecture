using Microsoft.EntityFrameworkCore;
using RentalQuotationModule.Core.Entities;
using RentalQuotationModule.Core.Interfaces;
using RentalQuotationModule.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentalQuotationModule.Infrastructure.Repositories
{
    public class ToDoRepository : ITodoRepository
    {
        private readonly RentalQuotationContext _context;

        public ToDoRepository(RentalQuotationContext context)
        {
            _context = context;
        }

        public async Task<List<Todo>> GetAllAsync()
        {
            return await _context.ToDoItems.ToListAsync();
        }

        public async Task<Todo> GetByIdAsync(int id)
        {
            return await _context.ToDoItems.FindAsync(id);
        }

        public async Task AddAsync(Todo toDo)
        {
            await _context.ToDoItems.AddAsync(toDo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Todo toDo)
        {
            _context.Entry(toDo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Todo toDo)
        {
            _context.ToDoItems.Remove(toDo);
            await _context.SaveChangesAsync();
        }
    }

}
