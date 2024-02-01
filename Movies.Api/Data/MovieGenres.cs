using System.Text.Json.Serialization;

namespace Movies.Api.Data
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MovieGenres
    {
        Action = 1,
        Comedy = 2,
        Drama = 3
    }
}
