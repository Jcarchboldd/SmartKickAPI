namespace Domain.Entities;

public class Player
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public string SkillLevel { get; set; } = string.Empty;
    public ICollection<BallMetrics> BallMetrics { get; set; } = new List<BallMetrics>();
}