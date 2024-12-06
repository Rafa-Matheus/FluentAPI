using Microsoft.AspNetCore.Mvc;

namespace FluentAPI.Controller;

[ApiController]
[Route("")]
public class HomeController : ControllerBase
{
    [HttpGet("health-check")]
    public IActionResult Get()
        => Ok("Welcome to this API!");
}