
using BusinessModel.Contracts;
using BusinessModel.Services;
using System.Text.Json.Serialization;
using WebApiContrib.Core.Formatter.Csv;

namespace VehicleManagementApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton<IVehicleService, StaticVehicleService>();

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    // Enum Serialization fixen: Farbe soll als String ausgegeben werden
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                })
                // Weitere Formatters hinzufuegen
                .AddXmlSerializerFormatters()
                // Install-Package WebApiContrib.Core.Formatter.Csv
                .AddCsvSerializerFormatters();

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
}
