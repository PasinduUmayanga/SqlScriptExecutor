using SSE.Models.Models;
using SSE.Services.Helpers;

namespace SSE.Tests;

public class JsonHelperTests
{
    private readonly JsonHelper _jsonHelper = new();

    [Fact]
    public void Deserialize_ReturnsConfig_WhenJsonIsValid()
    {
        const string json = """
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
        """;

        AppConfig? result = _jsonHelper.Deserialize<AppConfig>(json);

        Assert.NotNull(result);
        Assert.Equal("Inventory", result.DatabaseName);
        Assert.Equal("db_user", result.Username);
    }

    [Fact]
    public void Deserialize_ReturnsDefault_WhenJsonIsInvalid()
    {
        AppConfig? result = _jsonHelper.Deserialize<AppConfig>("{ invalid json");

        Assert.Null(result);
    }
}
