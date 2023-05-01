using Microsoft.EntityFrameworkCore;
using RentalQuotationModule.Core.Entities;

namespace RentalQuotationModule.Infrastructure.Data
{
    public class RentalQuotationContext : DbContext
    {
        public RentalQuotationContext(DbContextOptions<RentalQuotationContext> options)
            : base(options)
        {
        }

        public DbSet<Todo> ToDoItems { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RentalQuotationContext).Assembly);
        }
    }
    
}

