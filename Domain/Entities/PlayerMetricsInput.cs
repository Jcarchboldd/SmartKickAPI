namespace Domain.Entities;

public class PlayerMetricsInput
{
    public int PlayerId { get; set; }
    public float KickCount { get; set; }
    public float AverageSpin { get; set; }
    public float AverageHeight { get; set; }
    public int SessionsPlayed { get; set; }
}