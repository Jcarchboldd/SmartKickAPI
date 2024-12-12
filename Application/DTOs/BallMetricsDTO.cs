namespace Application.DTOs;

public class BallMetricsDTO
{
    public string? BallId { get; set; }
    public string? SessionId { get; set; }
    public float Speed { get; set; }
    public float Spin { get; set; }
    public float Height { get; set; }
    public int PlayerId { get; set; }
}