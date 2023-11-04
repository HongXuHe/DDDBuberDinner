using System.Net;
using BuberDinner.Application.Authentication;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;
[ApiController]
[Route("api/auth")]
public class AuthenticationController:ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var result =_authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);

        return  result.Match(authResult => Ok(MapAuthResult(authResult)),
            error => Problem(statusCode: error.StatusCode, title: error.Message));
      
    }

    [HttpPost("login")]             
    public IActionResult Login(LoginRequest request)
    {
        var authResult =_authenticationService.Login( request.Email, request.Password);
        var response = new AuthenticationResponse(authResult.User.Id, authResult.User.FirstName, authResult.User.LastName,
            authResult.User.Email, authResult.Token);
        return Ok(response);
    }

    [NonAction]
    private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    {
        return  new AuthenticationResponse(authResult.User.Id, authResult.User.FirstName, authResult.User.LastName,
            authResult.User.Email, authResult.Token);
    }
}