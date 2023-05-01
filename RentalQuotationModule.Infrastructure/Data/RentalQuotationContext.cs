using Microsoft.EntityFrameworkCore;
using RentalQuotationModule.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalQuotationModule.Infrastructure.Data
{
    public class RentalQuotationContext : DbContext
    {
        public RentalQuotationContext(DbContextOptions<RentalQuotationContext> options)
            : base(options)
        {
        }

        public DbSet<Todo> ToDoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RentalQuotationContext).Assembly);
        }
    }
    
}

