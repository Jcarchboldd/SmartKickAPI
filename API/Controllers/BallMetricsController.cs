using API.ViewModels;
using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BallMetricsController :  ControllerBase
{
    private readonly IBallMetricsService _ballMetricsService;

    public BallMetricsController(IBallMetricsService ballMetricsService)
    {
        _ballMetricsService = ballMetricsService;
    }
    
    /// <summary>
    /// Retrieves all ball metrics.
    /// </summary>
    /// <returns>
    /// A JSON object containing a list of all ball metrics.
    /// </returns>
    /// <response code="200">Returns the list of ball metrics.</response>
    /// <response code="500">If an internal server error occurs.</response>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var metrics = await _ballMetricsService.GetAllAsync();
        return Ok(new ApiResponse<IEnumerable<BallMetricsDTO>>(metrics));
    }

    /// <summary>
    /// Retrieves a specific ball metric by ID.
    /// </summary>
    /// <param name="id" example="1">The ID of the ball metric to retrieve.</param>
    /// <returns>
    /// A JSON object containing the details of the requested ball metric.
    /// </returns>
    /// <response code="200">Returns the requested ball metric.</response>
    /// <response code="404">If the ball metric is not found.</response>
    /// <response code="500">If an internal server error occurs.</response>
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var metric = await _ballMetricsService.GetByIdAsync(id);
        if (metric == null)
        {
            return NotFound(new ApiResponse<string>("Metric not found"));
        }
        return Ok(new ApiResponse<BallMetricsDTO>(metric));
    }

    /// <summary>
    /// Retrieves player metrics.
    /// </summary>
    /// <param name="playerId"></param>
    /// <returns>player with average metrics.</returns>
    /// <response code="200">Returns the player metrics.</response>
    /// <response code="404">No player found.</response>
    /// <response code="500">Internal server error.</response>
    [HttpGet("player-metrics")]
    public async Task<IActionResult> GetAggregatedMetrics(int playerId)
    {
        var playerMetrics = await _ballMetricsService.GetPlayerWithMetricsAsync(playerId);

        if (playerMetrics == null)
        {
            return NotFound(new ApiResponse<string>("No player metrics found"));
        }
        return Ok(new ApiResponse<PlayerMetricsInputDTO>(playerMetrics));
    }
    
    /// <summary>
    /// Adds a new ball metric.
    /// </summary>
    /// <param name="dto">The ball metric data to add.</param>
    /// <returns>
    /// A JSON object indicating the creation of the ball metric.
    /// </returns>
    /// <response code="201">If the ball metric is successfully created.</response>
    /// <response code="400">If the input data is invalid.</response>
    /// <response code="500">If an internal server error occurs.</response>
    [HttpPost]
    public async Task<IActionResult> AddBallMetrics([FromBody] BallMetricsDTO dto)
    {
        var createdId = await _ballMetricsService.AddAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = createdId }, new ApiResponse<string>("Metric created successfully"));
    }
}