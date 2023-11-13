using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;
[Route("api/[controller]")]
public class DinnersController:BaseController
{
    [HttpGet]
    public IActionResult ListDinner()
    {
        return Ok(Array.Empty<string>());
    }
}