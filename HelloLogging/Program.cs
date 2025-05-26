
using OpenTelemetry.Exporter;
using OpenTelemetry.Logs;
using OpenTelemetry.Resources;

namespace HelloLogging
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Logging konfigurieren
            // Vordefinierte Config von ASP.NET Core entfernen
            builder.Logging.ClearProviders();

            // Install-Package OpenTelemetry.Instrumentation.AspNetCore
            // Install-Package OpenTelemetry.Exporter.Console
            builder.Logging.AddOpenTelemetry(options => options.AddConsoleExporter());

            // Install-Package OpenTelemetry.Exporter.OpenTelemetryProtocol
            var otlpEndpoint = new Uri("http://localhost:5341/ingest/otlp/v1/logs");
            builder.Logging.AddOpenTelemetry(options =>
            {
                options.SetResourceBuilder(ResourceBuilder.CreateEmpty()
                    .AddService("WeatherService")
                    .AddAttributes(new Dictionary<string, object>
                    {
                        ["version"] = "1.0.0",
                        ["deployment.environment"] = builder.Environment.EnvironmentName
                    }));

                options.IncludeScopes = true;
                options.IncludeFormattedMessage = true;
                options.AddOtlpExporter(config =>
                {
                    config.Endpoint = otlpEndpoint;
                    config.Protocol = OtlpExportProtocol.HttpProtobuf;
                    config.Headers = "X-Seq-ApiKey=3CzFSmxsPHY4Bi6H41mh";
                });
            });

            // Add services to the container.

            builder.Services.AddControllers();
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
