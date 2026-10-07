using Microsoft.AspNetCore.Mvc;

namespace Patient.API.Controllers;

[ApiController]
[Route("api/health")]
public sealed class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        // This checks API liveness only; no database is configured yet.
        return Ok(new { service = "Patient", status = "healthy" });
    }
}
