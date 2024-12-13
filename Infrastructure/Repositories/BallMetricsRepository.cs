using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BallMetricsRepository : IBallMetricsRepository
{
    private readonly ApplicationDbContext _context;
    
    public BallMetricsRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<BallMetric?>> GetAllAsync()
    {
        return await _context.BallMetrics.ToListAsync();
    }

    public async Task<BallMetric?> GetByIdAsync(int id)
    {
        return await _context.BallMetrics.FindAsync(id);
    }

    public async Task AddAsync(BallMetric ballMetric)
    {
        ballMetric.Timestamp = DateTime.Now;
        await _context.BallMetrics.AddAsync(ballMetric);
    }
}