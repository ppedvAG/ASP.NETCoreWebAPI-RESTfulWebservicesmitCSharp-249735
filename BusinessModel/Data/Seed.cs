using Bogus;
using BusinessModel.Models;
using Microsoft.AspNetCore.Identity;
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

    #region Seed Vehicles
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
    #endregion

    #region Seed Identity
    public const string ADMIN_ROLE_ID = "d4e8321b-447b-43d2-bdce-f4738b588bec";
    public const string ADMIN_ROLE = "Admin";
    public const string USER_ROLE_ID = "eb6b2a41-9e08-4243-bf9b-74f5ac6d9297";
    public const string USER_ROLE = "User";

    public const string ROOT_USER_ID = "3a32e868-9191-4c77-a8ea-4c825571b5bf";
    public const string ROOT_USER_NAME = "R. Root";
    public const string ROOT_USER_EMAIL = "root@example.com";

    public const string JOHN_USER_ID = "4b43c757-9e01-4243-bf9b-f4738b588bec";
    public const string JOHN_USER_NAME = "John Doe";
    public const string JOHN_USER_EMAIL = "john.doe@example.com";

    // Syst3m
    public const string DEFAULT_PWD_HASH = "AQAAAAIAAYagAAAAEI9bnzxidZZ+yhCWxSEb3S6FK1cSyK/2GPjRLnssQErapeLrjxRDdlzL22WyyowLRA==";

    public static List<IdentityRole> Roles =>
    [
        new IdentityRole
        {
            Id = ADMIN_ROLE_ID,
            Name = ADMIN_ROLE,
            NormalizedName = ADMIN_ROLE.ToUpper()
        },
        new IdentityRole
        {
            Id = USER_ROLE_ID,
            Name = USER_ROLE,
            NormalizedName = USER_ROLE.ToUpper()
        },
    ];

    public static List<IdentityUser> Users =>
    [
        new IdentityUser
        {
            Id = ROOT_USER_ID,
            UserName = ROOT_USER_NAME,
            NormalizedUserName = ROOT_USER_NAME.ToUpper(),
            Email = ROOT_USER_EMAIL,
            NormalizedEmail = ROOT_USER_EMAIL.ToUpper(),
            PasswordHash = DEFAULT_PWD_HASH
        },
        new IdentityUser
        {
            Id = JOHN_USER_ID,
            UserName = JOHN_USER_NAME,
            NormalizedUserName = JOHN_USER_NAME.ToUpper(),
            Email = JOHN_USER_EMAIL,
            NormalizedEmail = JOHN_USER_EMAIL.ToUpper(),
            PasswordHash = DEFAULT_PWD_HASH
        }
    ];

    public static List<IdentityUserRole<string>> UsersRoles =>
    [
        new IdentityUserRole<string>
        {
            RoleId = ADMIN_ROLE_ID,
            UserId = ROOT_USER_ID
        },
        new IdentityUserRole<string>
        {
            RoleId = USER_ROLE_ID,
            UserId = JOHN_USER_ID
        }
    ];

    internal static void InitIdentityData(ModelBuilder builder)
    {
        builder.Entity<IdentityRole>().HasData(Roles);
        builder.Entity<IdentityUser>().HasData(Users);
        builder.Entity<IdentityUserRole<string>>().HasData(UsersRoles);
    }
    #endregion
}