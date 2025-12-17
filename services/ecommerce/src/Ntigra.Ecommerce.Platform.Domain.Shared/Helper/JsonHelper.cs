using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ntigra.Ecommerce.Platform.Domain.Shared.Helper;

public class JsonHelper
{
    public static string SerializeWithOptions(object json)
    {
        try
        {
            var options = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                Converters =
                {
                    new JsonStringEnumConverter()
                },
            };

            return JsonSerializer.Serialize(json, options);
        }
        catch
        {
            return null;
        }
    }
}