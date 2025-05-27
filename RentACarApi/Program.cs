
using BusinessModel.Contracts;
using BusinessModel.Data;
using BusinessModel.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace RentACarApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var connectionString = builder.Configuration.GetConnectionString("Default");
        builder.Services.AddDbContext<VehicleDbContext>(options => options.UseSqlServer(connectionString));
        builder.Services.AddTransient<IVehicleService, VehicleService>();

        builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                // Enum Serialization fixen: Farbe soll als String ausgegeben werden
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
