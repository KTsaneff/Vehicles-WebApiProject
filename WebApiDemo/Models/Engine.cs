using System.Text.Json.Serialization;

namespace WebApiDemo.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Engine
    {
        Diesel = 1,
        Petrol,
        LPG,
        Hybrid,
        Electric
    }
}
