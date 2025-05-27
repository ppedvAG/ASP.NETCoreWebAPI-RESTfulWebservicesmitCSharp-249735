using Bogus;
using BusinessModel.Models;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace BusinessModel.Data;

public class Seed
{
    #region Constants
    // Fuer Tests ist es besser die Testdaten nicht via Bogus zur Laufzeit generieren zu lassen
    // sondern hier explizit auszuschreiben. Weil wir einen Seed verwenden, ist diese Guid konstant.
    public const string Vehicle1Id = "098B6ECC-5714-B09A-36CF-D6280BB3C707";
    public const string Vehicle1Manufacturer = "Porsche";
    public const string Vehicle1Model = "A4";
    public const string Vehicle1Fuel = "Diesel";
    public const int Vehicle1TopSpeed = 100; 
    #endregion

    // Install-Package Bogus
    public static IEnumerable<Auto> GenerateAutos(int count)
    {
        int colorCount = Enum.GetNames<KnownColor>().Length;

        var cars = new Faker<Auto>()
            .UseSeed(42)
            .RuleFor(x => x.Id, f => f.Random.Guid())
            .RuleFor(x => x.Manufacturer, f => f.Vehicle.Manufacturer())
            .RuleFor(x => x.Model, f => f.Vehicle.Model())
            .RuleFor(x => x.Type, f => f.Vehicle.Type())
            .RuleFor(x => x.Fuel, f => f.Vehicle.Fuel())
            .RuleFor(x => x.TopSpeed, f => f.Random.Int(10, 30) * 10)
            .RuleFor(x => x.Color, f => (KnownColor)f.Random.Int(28, colorCount))
            .RuleFor(x => x.Registered, f => f.Date.Between(new DateTime(1990, 1, 1), new DateTime(2022, 1, 1)))
            .Generate(count);

        return cars;
    }

    public static IEnumerable<Customer> GenerateCustomers(int count) => new Faker<Customer>()
            .UseSeed(42)
            .RuleFor(x => x.Id, f => f.Random.Guid())
            .RuleFor(x => x.Name, f => f.Person.FullName)
            .RuleFor(x => x.Email, f => f.Person.Email)
            .Generate(count);

    public static void SeedData(ModelBuilder builder)
    {
        builder.Entity<Auto>().HasData(GenerateAutos(100));
        builder.Entity<Customer>().HasData(GenerateCustomers(10));
    }
}