namespace Domain.Entities;

public class Point
{
    public decimal Longitude { get; set; }
    public decimal Latitude { get; set; }
    public string? Title { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public string? Website { get; set; }
}