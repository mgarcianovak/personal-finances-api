using Microsoft.EntityFrameworkCore;
using PersonalFinances.API.Entities;

namespace PersonalFinances.API.Data;

public class PersonalFinancesContext(DbContextOptions<PersonalFinancesContext> options) 
    : DbContext(options)
{
    public DbSet<Transaction> Transactions => Set<Transaction>();
    
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new { Id = 1, Name = "Servicios" },
            new { Id = 2, Name = "Ocio" },
            new { Id = 3, Name = "Compras" },
            new { Id = 4, Name = "Transporte" },
            new { Id = 5, Name = "Cuotas" }
        );
    }

}
