using SSE.Services.Interfaces;

namespace SSE.Services.Helpers
{
    public class JsonHelper : IJsonHelper
    {
        public T? Deserialize<T>(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                return default;
            }
            try
            {
                return System.Text.Json.JsonSerializer.Deserialize<T>(json);
            }
            catch (System.Text.Json.JsonException)
            {
                return default;
            }
        }
        public string Serialize<T>(T obj)
        {
            return System.Text.Json.JsonSerializer.Serialize(obj);
        }
    }
}
