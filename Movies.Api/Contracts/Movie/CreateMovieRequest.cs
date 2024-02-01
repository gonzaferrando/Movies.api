using Movies.Api.Data;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Movies.Api.Contracts.Movie
{
    public class CreateMovieRequest
    {
        [MinLength(1), MaxLength(50)]
        public string Title { get; set; } = string.Empty;

        [MinLength(1), MaxLength(200)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please add a valid genre."), EnumDataType(typeof(MovieGenres))]
        public MovieGenres? Genre { get; set; }

        [Required]
        [JsonPropertyName("release_date")]
        public DateTime? ReleaseDate { get; set; }
    }
}
