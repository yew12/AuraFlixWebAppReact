using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AuraFlixWebApi.Models
{
    public class Movie
    {
        [Column("movie_id")]
        public int MovieId { get; set; }
        [Column("title")]
        public string? Title { get; set; }
        [Column("tagline")]
        public string? Tagline { get; set; }
        [Column("description")]
        public string? Description { get; set; }
        [Column("movie_poster")]
        public string? MoviePoster { get; set; }
        public string PosterUrl => $"https://image.tmdb.org/t/p/w200{MoviePoster}"; // Computed property
        [Column("release_date")]
        public DateTime? ReleaseDate { get; set; }
        [Column("rating")]
        public double Rating { get; set; }
        [Column("total_ratings")]
        public int TotalRatings { get; set; }

        public ICollection<MovieCast> Cast { get; set; } = new List<MovieCast>();
    }
}