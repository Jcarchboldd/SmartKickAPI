namespace Domain.Entities;

public class Player
{
    public int PlayerId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public string SkillLevel { get; set; } = string.Empty;
    
    public ICollection<Session> Sessions { get; set; } = new List<Session>();
}