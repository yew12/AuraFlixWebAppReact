using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuraFlixWebApi.Models;

public class Actor
{
    [Column("id")]
    public int Id { get; set; }
    [Column("name")]
    [Required]
    public required string Name { get; set; }
    public ICollection<MovieCast> Movies { get; set; } = new List<MovieCast>();
}