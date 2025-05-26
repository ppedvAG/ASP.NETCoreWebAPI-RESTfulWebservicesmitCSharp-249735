using Bogus;
using BusinessModel.Models;
using System.Drawing;

namespace BusinessModel.Data;

public class Seed
{
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
}