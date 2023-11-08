using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class BaseController:ControllerBase
{
    
}