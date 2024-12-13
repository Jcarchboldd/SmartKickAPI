namespace Domain.Entities;

public class Session
{
    public string SessionId { get; set; } = string.Empty;
    public int PlayerId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public double TotalTime => (EndTime - StartTime).TotalSeconds;
    
    public Player Player { get; set; } = null!;
    public ICollection<BallMetric> BallMetrics { get; set; } = new List<BallMetric>();
    public Error? Error { get; set; } 
}