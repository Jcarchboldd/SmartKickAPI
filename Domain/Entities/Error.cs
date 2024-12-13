namespace Domain.Entities;

public class Error
{
    public int ErrorId { get; set; }
    public string SessionId { get; set; } = string.Empty;
    public int MissedKicks { get; set; }
    public float RecoveryTime { get; set; }
    
    public Session Session { get; set; } = null!;
}