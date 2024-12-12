namespace Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IBallMetricsRepository BallMetricsRepository { get; }
    IPlayerRepository PlayerRepository { get; }
    Task<int> SaveChangesAsync();
}