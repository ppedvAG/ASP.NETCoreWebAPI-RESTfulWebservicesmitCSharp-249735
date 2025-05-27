using BusinessModel.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BusinessModel.Data;

public class VehicleDbContext : IdentityDbContext
{
    public DbSet<Auto> Vehicles { get; set; }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Order> Orders { get; set; }

    public VehicleDbContext(DbContextOptions<VehicleDbContext> options) 
        : base(options)
    {        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        Seed.InitIdentityData(modelBuilder);

        Seed.SeedData(modelBuilder);
    }
}
