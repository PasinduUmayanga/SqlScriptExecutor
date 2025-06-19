using SSE.Models.Models;
using SSE.Services.Helpers;
using SSE.Services.Interfaces;

namespace SSE.Services.Services
{
    public class ExecutorService(IFileHelper fileHelper, IJsonHelper jsonHelper) : IExecutorService
    {
        private readonly IFileHelper _FileHelper = fileHelper;
        private readonly IJsonHelper _JsonHelper = jsonHelper;

        public AppConfig ReadAppConfig()
        {
            string appConfigString = _FileHelper.ReadFile("Appconfig.json");
            AppConfig appConfig = _JsonHelper.Deserialize<AppConfig>(appConfigString) ?? new AppConfig();
            return appConfig;
        }
    }
}
