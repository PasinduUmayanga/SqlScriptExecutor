using SSE.Services.Interfaces;

namespace SSE.Services.Helpers
{
    public class FileHelper : IFileHelper
    {
        public string ReadFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                return string.Empty;
            }
            try
            {
                return File.ReadAllText(filePath);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
