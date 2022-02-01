using System.Text.Json;
using System.Text.Json.Serialization;

namespace Chinook.Service.Configuration;

public static class JsonSerializerConfig
{
    public static JsonSerializerOptions JsonSerializerOptions { get; } = new()
    {
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
        PropertyNamingPolicy = new SnakeCaseNamingPolicy()
    };

}

public static class ExtensionMethods
{

    public static string ToSnakeCase(this string str)
    {
        return string.Concat(
            str.Select(
                (x, i) => i > 0 && char.IsUpper(x)
                    ? "_" + x
                    : x.ToString()
            )
        ).ToLower();
    }
}

public class SnakeCaseNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name)
    {
        return name.ToSnakeCase();
    }
}