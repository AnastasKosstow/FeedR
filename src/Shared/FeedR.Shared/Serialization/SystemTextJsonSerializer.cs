using System.Text.Json;

namespace FeedR.Shared.Serialization;

internal sealed class SystemTextJsonSerializer : ISerializer
{
    private static readonly JsonSerializerOptions jsonSerializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = true,
    };

    public string Serialize<T>(T value) where T : class
        => JsonSerializer.Serialize<T>(value, jsonSerializerOptions);

    public T? Deserialize<T>(string value) where T : class
        => JsonSerializer.Deserialize<T>(value, jsonSerializerOptions);
}
