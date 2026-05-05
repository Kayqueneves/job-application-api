using Microsoft.AspNetCore.Mvc;

namespace JobApplicationAPI.Controller;

[ApiController]
[Route("api/[controller]")]
public class UserControllerController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }
}
