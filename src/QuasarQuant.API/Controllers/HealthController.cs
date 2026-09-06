using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace QuasarQuant.API.Controllers;

[ApiController]
[Route("health")]
public class HealthController : Controller
{
    [HttpGet]
    public IActionResult GetHealth()
    {
        var watch = Stopwatch.StartNew();
        watch.Stop();

        var healthReport = new
        {
            status = "Healthy",
            statusCode = StatusCodes.Status200OK,
            message = "API is operational.",
            responseTime = $"{watch.Elapsed.TotalMilliseconds:F2} ms",
            timestamp = DateTime.UtcNow
        };

        return Ok(healthReport);
    }
}
