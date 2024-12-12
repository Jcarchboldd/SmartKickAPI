using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
    
    public DbSet<Player> Players { get; set; }
    public DbSet<BallMetrics> BallMetrics { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure Player entity
        modelBuilder.Entity<Player>()
            .HasKey(p => p.Id);

        modelBuilder.Entity<Player>()
            .Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<Player>()
            .Property(p => p.Age)
            .IsRequired();

        modelBuilder.Entity<Player>()
            .Property(p => p.SkillLevel)
            .IsRequired()
            .HasMaxLength(50);

        modelBuilder.Entity<Player>()
            .HasMany(p => p.BallMetrics)
            .WithOne(b => b.Player)
            .HasForeignKey(b => b.PlayerId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure BallMetrics entity
        modelBuilder.Entity<BallMetrics>()
            .HasKey(b => b.Id);

        modelBuilder.Entity<BallMetrics>()
            .Property(b => b.BallId)
            .IsRequired()
            .HasMaxLength(50);

        modelBuilder.Entity<BallMetrics>()
            .Property(b => b.SessionId)
            .IsRequired()
            .HasMaxLength(50);

        modelBuilder.Entity<BallMetrics>()
            .Property(b => b.Timestamp)
            .IsRequired();

        modelBuilder.Entity<BallMetrics>()
            .Property(b => b.Speed)
            .IsRequired();

        modelBuilder.Entity<BallMetrics>()
            .Property(b => b.Spin)
            .IsRequired();

        modelBuilder.Entity<BallMetrics>()
            .Property(b => b.Height)
            .IsRequired();

        base.OnModelCreating(modelBuilder);
    }

    public void SeedData()
    {
        if (Players.Any()) return;
        
        Players.AddRange(
            new Player
            {
                Id = 1,
                Name = "John Doe",
                Age = 25,
                SkillLevel = "Intermediate"
            },
            new Player
            {
                Id = 2,
                Name = "Jane Smith",
                Age = 22,
                SkillLevel = "Beginner"
            },
            new Player
            {
                Id = 3,
                Name = "Mark Johnson",
                Age = 28,
                SkillLevel = "Advanced"
            }
        );
            
        BallMetrics.AddRange(
            new BallMetrics
            {
                Id = 1,
                BallId = "ball001",
                PlayerId = 1,
                SessionId = "session001",
                Timestamp = DateTime.Now.AddDays(-2),
                Speed = 22.5f,
                Spin = 1200.0f,
                Height = 1.5f
            },
            new BallMetrics
            {
                Id = 2,
                BallId = "ball002",
                PlayerId = 2,
                SessionId = "session002",
                Timestamp = DateTime.Now.AddDays(-1),
                Speed = 18.0f,
                Spin = 1100.0f,
                Height = 1.2f
            },
            new BallMetrics
            {
                Id = 3,
                BallId = "ball003",
                PlayerId = 3,
                SessionId = "session003",
                Timestamp = DateTime.Now,
                Speed = 25.7f,
                Spin = 1300.0f,
                Height = 1.8f
            }
        );
        
        SaveChanges();
    }
    
}