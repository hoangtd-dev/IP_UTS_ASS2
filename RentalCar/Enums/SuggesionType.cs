using System.Text.Json.Serialization;

namespace RentalCar.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]

    public enum SuggestionType
    {
        CarName,
        CarBrand,
        CarType
    }
}
