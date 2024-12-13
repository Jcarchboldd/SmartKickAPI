namespace Domain.Entities;

public class BallMetric
{
    public int MetricId { get; set; }
    public string SessionId { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; }
    public int KickCount { get; set; }
    public float AverageHeight { get; set; }
    public float MaxHeight { get; set; }
    public float MinHeight { get; set; }
    public float TimeBetweenKicks { get; set; }
    public float KickAccuracy { get; set; }
    public float Spin { get; set; }
    public float KickForce { get; set; }
    
    public Session Session { get; set; } = null!;
}