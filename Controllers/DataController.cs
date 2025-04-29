using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CallLogsAPI.Data;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CallLogsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class DataController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<DataController> _logger;

        public DataController(AppDbContext context, ILogger<DataController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("/location")]
        public async Task<IActionResult> GetLocationDetails()
        {
            try
            {
                _logger.LogInformation("Retrieving all location details");
                var locations = await _context.LocationDetail.ToListAsync();
                return Ok(locations);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving location details");
                return StatusCode(500, "An error occurred while retrieving data");
            }
        }
        
        [HttpGet("/location/{userId}")]
        public async Task<IActionResult> GetLocationDetailsById(int userId)
        {
            try
            {
                var location = await _context.LocationDetail.FindAsync(userId);
                if (location == null)
                {
                    return NotFound();
                }
                return Ok(location);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving location detail with ID: {Id}", userId);
                return StatusCode(500, "An error occurred while retrieving data");
            }
        }

        [HttpGet("/calllog")]
        public async Task<IActionResult> GetCallLogDetailsDetails()
        {
            try
            {
                _logger.LogInformation("Retrieving all call log details");
                var locations = await _context.CallLogDetail.ToListAsync();
                return Ok(locations);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving call log details");
                return StatusCode(500, "An error occurred while retrieving data");
            }
        }

        [HttpGet("/calllog/{sessionId}")]
        public async Task<IActionResult> GetCallLogDetailsDetailsById(int sessionId)
        {
            try
            {
                var location = await _context.CallLogDetail.FindAsync(sessionId);
                if (location == null)
                {
                    return NotFound();
                }
                return Ok(location);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving Call Log detail with ID: {Id}", sessionId);
                return StatusCode(500, "An error occurred while retrieving data");
            }
        }

        [HttpGet("/callbound")]
        public async Task<IActionResult> GetCallBoundDetailsDetails()
        {
            try
            {
                _logger.LogInformation("Retrieving all call bound details");
                var locations = await _context.CallBoundDetail.ToListAsync();
                return Ok(locations);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving call bound details");
                return StatusCode(500, "An error occurred while retrieving data");
            }
        }

        [HttpGet("/callbound/{userId}")]
        public async Task<IActionResult> GetCallBoundDetailsDetailsById(int userId)
        {
            try
            {
                var location = await _context.CallBoundDetail.FindAsync(userId);
                if (location == null)
                {
                    return NotFound();
                }
                return Ok(location);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving Call Bound detail with ID: {Id}", userId);
                return StatusCode(500, "An error occurred while retrieving data");
            }
        }
    }
}