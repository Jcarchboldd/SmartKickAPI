namespace Application.DTOs;

public class PlayerMetricsInputDTO
{
    public int PlayerId { get; set; }
    public float AverageSpeed { get; set; }
    public float AverageSpin { get; set; }
    public float AverageHeight { get; set; }
}