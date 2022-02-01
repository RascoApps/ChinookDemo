using System.ComponentModel.DataAnnotations;

namespace Chinook.DataStore.SqlServer;

public class Parcel
{
    [Key]
    public Guid ParcelId { get; set; }
    [Required] 
    public Track Track { get; set; } = null!;
    [Required]
    public DateTime CreatedAt { get; set; }
    [Required]
    public DateTime UpdatedAt { get; set; }
    [Required]
    public float Length { get; set; } = 8;
    [Required]
    public float Width { get; set; } = 6;
    [Required]
    public float Height { get; set; } = 5;
    [Required]
    public float Weight { get; set; } = 10;
}