using BusinessModel.Data;
using Microsoft.EntityFrameworkCore;

namespace BusinessModel.Tests;

public class TestDatabase : IDisposable
{
    const string ConnectionString = @"Server=(localdb)\AspNetWebApi;Database=UnitTests_{0};Trusted_Connection=True;MultipleActiveResultSets=true";
    
    private VehicleDbContext _context;

    public VehicleDbContext Context => _context ??= CreateContext();

    private VehicleDbContext CreateContext()
    {
        string id = Guid.NewGuid().ToString()[^4..];
        string connectionString = string.Format(ConnectionString, id);

        var options = new DbContextOptionsBuilder<VehicleDbContext>()
            .UseSqlServer(connectionString).Options;

        var context = new VehicleDbContext(options);

        // Datenbank erzeugen
        //context.Database.EnsureCreated();

        // Datenbank erzeugen & migrieren
        context.Database.Migrate();

        return context;
    }

    public void Dispose()
    {
        _context?.Database.EnsureDeleted();
        _context?.Dispose();
    }
}