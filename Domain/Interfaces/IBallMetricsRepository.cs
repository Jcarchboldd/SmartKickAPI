using Domain.Entities;

namespace Domain.Interfaces;

public interface IBallMetricsRepository
{
    Task<IEnumerable<BallMetrics?>> GetAllAsync();
    Task<BallMetrics?> GetByIdAsync(int id);
    Task AddAsync(BallMetrics ballMetrics);
}