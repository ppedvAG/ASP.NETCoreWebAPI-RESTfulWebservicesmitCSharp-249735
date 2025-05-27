using BusinessModel.Data;
using BusinessModel.Models;
using BusinessModel.Services;

namespace BusinessModel.Tests;

[TestClass]
public sealed class VehicleServiceTests
{
    [TestMethod]
    [DataRow(Seed.Vehicle1Id)]
    public async Task GetVehicleById_ValidId_ReturnsCorrectVehicleAsync(string vehicleId)
    {
        using (var db = new TestDatabase())
        {
            // Arrange
            var sut = new VehicleService(db.Context);

            // Act
            var result = await sut.GetVehicleById(Guid.Parse(vehicleId));

            // Assert
            Assert.IsNotNull(result, "Vehicle not found.");
            Assert.AreEqual(Seed.Vehicle1Manufacturer, result.Manufacturer);
            Assert.AreEqual(Seed.Vehicle1Model, result.Model);
            Assert.AreEqual(Seed.Vehicle1Fuel, result.Fuel);
            Assert.AreEqual(Seed.Vehicle1TopSpeed, result.TopSpeed);
        }
    }

    [TestMethod]
    public async Task GetVehicleById_InvalidId_ReturnsNullAsync()
    {
        using (var db = new TestDatabase())
        {
            // Arrange
            var sut = new VehicleService(db.Context);

            // Act 
            var result = await sut.GetVehicleById(Guid.NewGuid());

            // Assert
            Assert.IsNull(result);
        }
    }

    [TestMethod]
    public async Task GetVehicles_NoParameters_ReturnsAllVehiclesAsync()
    {
        using (var db = new TestDatabase())
        {
            // Arrange
            var sut = new VehicleService(db.Context);
            string[] expectedFuels = [ "Diesel", "Gasoline", "Hybrid", "Electric" ];

            // Act
            var result = (await sut.GetVehicles()).ToArray();

            // Assert
            Assert.AreEqual(100, result.Length);
            var actualFuels = result.Select(v => v.Fuel).Distinct().ToArray();
            CollectionAssert.AreEquivalent(expectedFuels, actualFuels);
        }
    }

    [TestMethod]
    public async Task AddVehicles_ValidVehicles_AddsVehiclesAsync()
    {
        using (var db = new TestDatabase())
        {
            // Arrange
            var sut = new VehicleService(db.Context);
            var vehicle = new Auto
            {
                Manufacturer = "Audi",
                Model = "A4",
                Fuel = "Diesel",
                TopSpeed = 200,
                Color = System.Drawing.KnownColor.Black,
                Registered = new DateTime(2000, 1, 1),
                Type = "Sedan"
            };

            // Act
            await sut.AddVehicle(vehicle);

            // Wichtig: Nicht gegen Service gehen
            var result = await db.Context.Vehicles.FindAsync(vehicle.Id);

            Assert.IsNotNull(result, "Vehicle not created!");
            Assert.AreEqual(vehicle.Manufacturer, result.Manufacturer);
            Assert.AreEqual(vehicle.Model, result.Model);
            Assert.AreEqual(vehicle.Fuel, result.Fuel);
            Assert.AreEqual(vehicle.TopSpeed, result.TopSpeed);
            Assert.AreEqual(vehicle.Color, result.Color);
            Assert.AreEqual(vehicle.Registered, result.Registered);
            Assert.AreEqual(vehicle.Type, result.Type);
        }
    }

    [TestMethod]
    [DataRow(Seed.Vehicle1Id)]
    public async Task UpdateVehicle_ValidId_DeletesVehicleAsync(string vehicleId)
    {
        using (var db = new TestDatabase())
        {
            // Arrange
            var sut = new VehicleService(db.Context);
            var vehicle = new Auto
            {
                Manufacturer = "Audi",
                Model = "A4",
                Fuel = "Diesel",
                TopSpeed = 200,
                Color = System.Drawing.KnownColor.Black,
                Registered = new DateTime(2000, 1, 1),
                Type = "Sedan"
            };

            // Act
            var success = await sut.UpdateVehicle(Guid.Parse(vehicleId), vehicle);

            // Assert
            Assert.IsTrue(success, "Vehicle not updated.");
            var result = await db.Context.Vehicles.FindAsync(Guid.Parse(vehicleId));
            Assert.IsNotNull(result, "Vehicle result should not be null.");
            Assert.AreEqual(vehicle.Manufacturer, result.Manufacturer);
            Assert.AreEqual(vehicle.Model, result.Model);
            Assert.AreEqual(vehicle.Fuel, result.Fuel);
            Assert.AreEqual(vehicle.TopSpeed, result.TopSpeed);
            Assert.AreEqual(vehicle.Color, result.Color);
            Assert.AreEqual(vehicle.Registered, result.Registered);
            Assert.AreEqual(vehicle.Type, result.Type);
        }
    }

    [TestMethod]
    [DataRow(Seed.Vehicle1Id)]
    public async Task DeleteVehicle_ValidId_DeletesVehicleAsync(string vehicleId)
    {
        using (var db = new TestDatabase())
        {
            // Arrange
            var sut = new VehicleService(db.Context);

            // Act
            var success = await sut.DeleteVehicle(Guid.Parse(vehicleId));

            // Assert
            Assert.IsTrue(success, "Vehicle not deleted.");
            var result = await db.Context.Vehicles.FindAsync(Guid.Parse(vehicleId));
            Assert.IsNull(result, "Vehicle result should be null.");
        }
    }
}
