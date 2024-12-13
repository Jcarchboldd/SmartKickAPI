using Domain.Entities;

namespace Domain.Interfaces;

public interface IBallMetricsRepository
{
    Task<IEnumerable<BallMetric?>> GetAllAsync();
    Task<BallMetric?> GetByIdAsync(int id);
    Task AddAsync(BallMetric ballMetric);
}