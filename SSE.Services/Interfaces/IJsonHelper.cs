namespace SSE.Services.Interfaces
{
    public interface IJsonHelper
    {
        T? Deserialize<T>(string json);
    }
}
