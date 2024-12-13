using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<BallMetric, BallMetricsDTO>().ReverseMap();
        
        CreateMap<PlayerMetricsInput, PlayerMetricsInputDTO>().ReverseMap();
    }
}