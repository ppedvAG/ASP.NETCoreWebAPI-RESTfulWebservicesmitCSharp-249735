using Lab002_DependencyInjection.Services;
using Microsoft.AspNetCore.Mvc;

namespace LabDependencyInjection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddSingleton<IOperationSingleton, OperationService>();
            builder.Services.AddScoped<IOperationScoped, OperationService>();
            builder.Services.AddTransient<IOperationTransient, OperationService>();
            builder.Services.AddControllers();

            var app = builder.Build();

            app.MapControllerRoute("default", "{controller=Test}");

            app.Run();
        }
    }
}
