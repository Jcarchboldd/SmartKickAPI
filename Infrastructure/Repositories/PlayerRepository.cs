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
        // Retrieve player along with their sessions and ball metrics
        var player = await _context.Players
            .Include(p => p.Sessions)
            .ThenInclude(s => s.BallMetrics)
            .FirstOrDefaultAsync(p => p.PlayerId == playerId);

        // Return null if player or sessions are empty
        if (player == null || !player.Sessions.Any())
        {
            return null;
        }

        // Flatten all ball metrics across all sessions
        var allBallMetrics = player.Sessions
            .SelectMany(s => s.BallMetrics)
            .ToList();

        // Return null if no ball metrics exist
        if (allBallMetrics.Count == 0)
        {
            return null;
        }

        // Calculate metrics
        var playerMetricsInput = new PlayerMetricsInput
        {
            PlayerId = player.PlayerId,
            KickCount = allBallMetrics.Sum(m => m.KickCount),
            AverageSpin = allBallMetrics.Average(m => m.Spin),
            AverageHeight = allBallMetrics.Average(m => m.KickForce),
            SessionsPlayed = player.Sessions.Count
        };

        return playerMetricsInput;
    }
}