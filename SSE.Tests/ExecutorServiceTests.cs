using SSE.Services.Helpers;
using SSE.Services.Services;

namespace SSE.Tests;

public class ExecutorServiceTests
{
    [Fact]
    public void ReadAppConfig_ReturnsConfig_WhenExplicitPathContainsValidJson()
    {
        string filePath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid():N}.json");
        File.WriteAllText(filePath, """
        {
          "SqlDirectory": "C:\\SqlScriptRun\\Scripts",
          "ServerName": ".\\SQLEXPRESS",
          "DatabaseName": "Inventory",
          "Username": "db_user",
          "Password": "secret",
          "LogFile": "execution_log.txt",
          "ErrorDirectory": "C:\\SqlScriptRun\\error_directory",
          "SuccessDirectory": "C:\\SqlScriptRun\\success_directory"
        }
        """);

        try
        {
            var service = new ExecutorService(new FileHelper(), new JsonHelper());

            var result = service.ReadAppConfig(filePath);

            Assert.Equal("Inventory", result.DatabaseName);
            Assert.Equal(".\\SQLEXPRESS", result.ServerName);
        }
        finally
        {
            File.Delete(filePath);
        }
    }

    [Fact]
    public void ReadAppConfig_ThrowsFileNotFoundException_WhenConfigIsMissing()
    {
        var service = new ExecutorService(new FileHelper(), new JsonHelper());
        string missingPath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid():N}.json");

        Assert.Throws<FileNotFoundException>(() => service.ReadAppConfig(missingPath));
    }

    [Fact]
    public void ReadAppConfig_ThrowsInvalidOperationException_WhenConfigJsonIsInvalid()
    {
        string filePath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid():N}.json");
        File.WriteAllText(filePath, "{ invalid json");

        try
        {
            var service = new ExecutorService(new FileHelper(), new JsonHelper());

            Assert.Throws<InvalidOperationException>(() => service.ReadAppConfig(filePath));
        }
        finally
        {
            File.Delete(filePath);
        }
    }
}
