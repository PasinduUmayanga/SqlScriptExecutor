using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SSE.Services;
namespace SSE.Forms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using var app = CreateHostBuilder().Build();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            // Resolve the form with dependencies injected
            var form = app.Services.GetRequiredService<ExecutorForm>();
      
            Application.Run(form);
        }
        static IHostBuilder CreateHostBuilder() =>
           Host.CreateDefaultBuilder()
               .ConfigureServices((context, services) =>
               {
                   services.AddApplicationServices();
                   services.AddTransient<ExecutorForm>();
               });
    }
}
