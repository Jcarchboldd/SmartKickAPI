namespace Domain.Entities;

public class PlayerMetricsInput
{
    public int PlayerId { get; set; }
    public float AverageSpeed { get; set; }
    public float AverageAccuracy { get; set; }
    public float AverageSpin { get; set; }
    public float AverageHeight { get; set; }
    public int SessionsPlayed { get; set; }
}