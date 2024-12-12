using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PlayerRepository : IPlayerRepository
{
    private readonly ApplicationDbContext _context;

    public PlayerRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<PlayerMetricsInput?> GetPlayerWithMetricsAsync(int playerId)
    {
        var player = await _context.Players
            .Include(p => p.BallMetrics)
            .FirstOrDefaultAsync(p => p.Id == playerId);
        
        if (player == null || player.BallMetrics.Count == 0)
        {
            return null;
        }
        
        var playerMetricsInput = new PlayerMetricsInput
        {
            PlayerId = player.Id,
            AverageSpeed = player.BallMetrics.Average(m => m.Speed),
            AverageSpin = player.BallMetrics.Average(m => m.Spin),
            AverageHeight = player.BallMetrics.Average(m => m.Height),
            SessionsPlayed = player.BallMetrics.Count
        };

        return playerMetricsInput;
        
    }
}