using SSE.Models.Models;
using SSE.Services.Helpers;
using SSE.Services.Interfaces;

namespace SSE.Services.Services
{
    public class ExecutorService(IFileHelper fileHelper, IJsonHelper jsonHelper) : IExecutorService
    {
        private readonly IFileHelper _FileHelper = fileHelper;
        private readonly IJsonHelper _JsonHelper = jsonHelper;

        public AppConfig ReadAppConfig(string? configPath = null)
        {
            string resolvedPath = ResolveConfigPath(configPath);
            string appConfigString = _FileHelper.ReadFile(resolvedPath);

            if (string.IsNullOrWhiteSpace(appConfigString))
            {
                throw new FileNotFoundException($"Configuration file was not found or was empty: {resolvedPath}");
            }

            return _JsonHelper.Deserialize<AppConfig>(appConfigString)
                ?? throw new InvalidOperationException($"Configuration file is invalid: {resolvedPath}");
        }

        private static string ResolveConfigPath(string? configPath)
        {
            if (!string.IsNullOrWhiteSpace(configPath))
            {
                return configPath;
            }

            string localConfigPath = Path.Combine(AppContext.BaseDirectory, "AppConfig.json");
            if (File.Exists(localConfigPath))
            {
                return localConfigPath;
            }

            return Path.Combine(AppContext.BaseDirectory, "AppConfig.example.json");
        }
    }
}
