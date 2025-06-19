using Microsoft.Extensions.DependencyInjection;
using SSE.Services.Helpers;
using SSE.Services.Interfaces;
using SSE.Services.Services;

namespace SSE.Services
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            try
            {
                // Register application services
                services.AddScoped<IExecutorService, ExecutorService>();
                services.AddScoped<IFileHelper, FileHelper>();
                services.AddScoped<IJsonHelper, JsonHelper>();
                return services;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
