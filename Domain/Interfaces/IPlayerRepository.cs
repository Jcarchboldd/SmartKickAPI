using Domain.Entities;

namespace Domain.Interfaces;

public interface IPlayerRepository
{
    Task<PlayerMetricsInput?> GetPlayerWithMetricsAsync(int playerId);
}