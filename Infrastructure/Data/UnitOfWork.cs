using Domain.Interfaces;
using Infrastructure.Repositories;

namespace Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private IBallMetricsRepository? _ballMetricsRepository;
    private IPlayerRepository? _playerRepository;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public IBallMetricsRepository BallMetricsRepository
    {
        get
        {
            return _ballMetricsRepository ??= new BallMetricsRepository(_context);
        }
    }

    public IPlayerRepository PlayerRepository
    {
        get
        {
            return _playerRepository ??= new PlayerRepository(_context);
        }
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }
}