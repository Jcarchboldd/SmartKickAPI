using Application.DTOs;

namespace Application.Interfaces;

public interface IBallMetricsService
{
    Task<IEnumerable<BallMetricsDTO>> GetAllAsync();
    Task<BallMetricsDTO?> GetByIdAsync(int id);
    Task<int> AddAsync(BallMetricsDTO dto);
    Task<PlayerMetricsInputDTO?> GetPlayerWithMetricsAsync(int id);
}