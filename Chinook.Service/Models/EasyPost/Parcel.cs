namespace Chinook.Service.Models.EasyPost;

public class Parcel
{
    public string Id { get; set; }
    public string Object { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public float Length { get; set; }
    public float Width { get; set; }
    public float Height { get; set; }
    public float Weight { get; set; }
    public string Mode { get; set; }
}