


using System.Text.Json;

namespace IdentityServer8.Services.KeyManagement;

internal static class KeySerializer
{
    static JsonSerializerOptions _settings =
        new JsonSerializerOptions
        {
            IncludeFields = true
        };

    public static string Serialize<T>(T item)
    {
        return JsonSerializer.Serialize(item, item.GetType(), _settings);
    }

    public static T Deserialize<T>(string json)
    {
        return JsonSerializer.Deserialize<T>(json, _settings);
    }
}
