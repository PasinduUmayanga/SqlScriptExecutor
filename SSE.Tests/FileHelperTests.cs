using SSE.Services.Helpers;

namespace SSE.Tests;

public class FileHelperTests
{
    private readonly FileHelper _fileHelper = new();

    [Fact]
    public void ReadFile_ReturnsContent_WhenFileExists()
    {
        string filePath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid():N}.txt");
        File.WriteAllText(filePath, "script content");

        try
        {
            string result = _fileHelper.ReadFile(filePath);

            Assert.Equal("script content", result);
        }
        finally
        {
            File.Delete(filePath);
        }
    }

    [Fact]
    public void ReadFile_ReturnsEmptyString_WhenFileDoesNotExist()
    {
        string result = _fileHelper.ReadFile(Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid():N}.txt"));

        Assert.Equal(string.Empty, result);
    }
}
