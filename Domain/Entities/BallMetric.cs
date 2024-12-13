namespace Domain.Entities;

public class BallMetrics
{
    public int Id { get; set; }
    public string BallId { get; set; } = string.Empty;
    public string SessionId { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; }
    public float Speed { get; set; }
    public float Spin { get; set; }
    public float Height { get; set; }

    public int PlayerId { get; set; }
    public Player Player { get; set; }
}