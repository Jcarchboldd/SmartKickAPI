using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class BallMetricsService : IBallMetricsService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BallMetricsService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<BallMetricsDTO>> GetAllAsync()
    {
        var metrics = await _unitOfWork.BallMetricsRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<BallMetricsDTO>>(metrics);
    }

    public async Task<BallMetricsDTO?> GetByIdAsync(int id)
    {
        var metric = await _unitOfWork.BallMetricsRepository.GetByIdAsync(id);
        return metric == null ? null : _mapper.Map<BallMetricsDTO>(metric);
    }

    public async Task<int> AddAsync(BallMetricsDTO dto)
    {
        var metric = _mapper.Map<BallMetric>(dto);
        await _unitOfWork.BallMetricsRepository.AddAsync(metric);
        await _unitOfWork.SaveChangesAsync();
        
        return metric.MetricId;
    }
    
    public async Task<PlayerMetricsInputDTO?> GetPlayerWithMetricsAsync(int id)
    {
        var metrics = await _unitOfWork.PlayerRepository.GetPlayerWithMetricsAsync(id);
        return metrics == null ? null : _mapper.Map<PlayerMetricsInputDTO>(metrics);
   
    }
}